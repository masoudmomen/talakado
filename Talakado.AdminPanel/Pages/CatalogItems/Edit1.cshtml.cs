using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Talakado.AdminPanel.ViewModels.Catalogs;
using Talakado.Application.Catalogs.CatalogItems;
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
            var editRequest = new CatalogItemEditRequestDto();
            #region Fill Fields
            editRequest.Name = Request.Form["Name"];
            editRequest.CatalogBrandId = int.Parse(Request.Form["CatalogBrandId"]);
            editRequest.CatalogTypeId = int.Parse(Request.Form["CatalogTypeId"]);
            editRequest.AvailableStock = int.Parse(Request.Form["AvailableStock"]);
            editRequest.ReStockThreshold = int.Parse(Request.Form["ReStockThreshold"]);
            editRequest.MaxStockThreshold = int.Parse(Request.Form["MaxStockThreshold"]);
            editRequest.Price = int.Parse(Request.Form["Price"]);
            editRequest.Description = Request.Form["Description"];
            #endregion
            #region Add Image
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
            
            if (images.Count > 0)
            {
                editRequest.AddedImages = images;
            }
            #endregion
            #region Add Feature
            editRequest.AddedFeatures = Request.Form["AddedFeatures"];
            #endregion
            #region Remove Images and Feature
            editRequest.RemovedImages = Request.Form["RemovedImages"];
            editRequest.RemovedFeatures = Request.Form["RemovedFeatures"];
            #endregion

            return new JsonResult(editRequest);
        }

    }
}
