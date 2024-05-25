using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Talakado.AdminPanel.ViewModels.Catalogs;
using Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Talakado.Application.Catalogs.CatalogItems.CatalogItemServices;
using Talakado.Infrastructure.ExternalApi.ImageServer;

namespace Talakado.AdminPanel.Pages.CatalogItems
{
    public class Edit1Model : PageModel
    {
        private readonly ICatalogItemService catalogItemService;
        private readonly IMapper mapper;
        private readonly IImageUploadService imageUploadService;

        public Edit1Model(ICatalogItemService catalogItemService, IMapper mapper, IImageUploadService imageUploadService)
        {
            this.catalogItemService = catalogItemService;
            this.mapper = mapper;
            this.imageUploadService = imageUploadService;
        }
        [BindProperty]
        public CatalogItemViewModel CatalogItem { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Brands { get; set; }
        public List<string> Message { get; set; }
        //public CatalogItemEditRequestViewmodel Data { get; set; }
        public List<IFormFile> Files { get; set; }

        public void OnGet(int id)
        {
            Categories = new SelectList(catalogItemService.GetCatalogType(), "Id", "Type");
            Brands = new SelectList(catalogItemService.GetBrand(), "Id", "Brand");
            var model = catalogItemService.FindById(id);
            if (model.IsSuccess)
            {
                CatalogItem = mapper.Map<CatalogItemViewModel>(model.Data);
            }
            Message = model.Message;
        }

        public JsonResult OnPost()
        {
            Files = (List<IFormFile>)Request.Form.Files;
            
            //upload images:
            List<AddNewCatalogItemImage_Dto> images = new List<AddNewCatalogItemImage_Dto>();
            if (Files.Count > 0)
            {
                //Uploud
                var result = imageUploadService.Upload(Files);
                foreach (var item in result)
                {
                    images.Add(new AddNewCatalogItemImage_Dto { Src = item });
                }
            }
            //if (images.Count > 0)
            //{
            //    return new JsonResult(images);
            //}
            return new JsonResult(Request.Form);
        }

    }
}
