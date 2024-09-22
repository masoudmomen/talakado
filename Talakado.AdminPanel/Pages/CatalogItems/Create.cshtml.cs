 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Talakado.Application.Catalogs.CatalogItems.CatalogItemServices;
using Talakado.Application.Dtos;
using Talakado.Infrastructure.ExternalApi.ImageServer;

namespace Talakado.AdminPanel.Pages.CatalogItems
{
    public class CreateModel : PageModel
    {
        private readonly IAddNewCatalogItemService addNewCatalogItemService;
        private readonly ICatalogItemService catalogItemService;
        private readonly IImageUploadService imageUploadService;

        public CreateModel(IAddNewCatalogItemService addNewCatalogItemService, ICatalogItemService catalogItemService, IImageUploadService imageUploadService)
        {
            this.addNewCatalogItemService = addNewCatalogItemService;
            this.catalogItemService = catalogItemService;
            this.imageUploadService = imageUploadService;
        }
        [BindProperty]
        public AddNewCatalogItemDto Data { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Brands { get; set; }
        public List<IFormFile> Files { get; set; }
        public void OnGet()
        {
            Categories = new SelectList(catalogItemService.GetCatalogType(), "Id", "Type");
            Brands = new SelectList(catalogItemService.GetBrand(), "Id", "Brand");
            TempData["page"] = 5;
        }

        public  JsonResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new JsonResult(new BaseDto<int>(false, allErrors.Select(p => p.ErrorMessage).ToList(), 0));
            }
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                Files.Add(file);
            }
            List<AddNewCatalogItemImage_Dto> images = new List<AddNewCatalogItemImage_Dto>();
            if (Files.Count > 0)
            {
                //Uploud
                var result = imageUploadService.UploadMultipleAsync(Files).Result;
                foreach (var item in result.FileNameAddress)
                {
                    images.Add(new AddNewCatalogItemImage_Dto { Src = item });
                }
            }
            Data.Images = images;

            var resultService = addNewCatalogItemService.Execute(Data);
            return new JsonResult(resultService);
        }
    }
}
