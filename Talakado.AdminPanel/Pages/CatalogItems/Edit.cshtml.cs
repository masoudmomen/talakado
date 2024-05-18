using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Talakado.AdminPanel.ViewModels.Catalogs;
using Talakado.Application.Catalogs.CatalogItems;
using Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Talakado.Application.Catalogs.CatalogItems.CatalogItemServices;
using Talakado.Application.Dtos;
using Talakado.Infrastructure.ExternalApi.ImageServer;

namespace Talakado.AdminPanel.Pages.CatalogItems
{
    public class EditModel : PageModel
    {
        private readonly ICatalogItemService catalogItemService;
        private readonly IMapper mapper;
        private readonly IImageUploadService imageUploadService;

        public EditModel(ICatalogItemService catalogItemService, IMapper mapper, IImageUploadService imageUploadService)
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


        public JsonResult OnPostAsync()
        {
            if(Request.Form.Files.Count>0) 
            {
                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    var file = Request.Form.Files[i];
                    Files.Add(file);
                }
                return new JsonResult("File Uploaded in Memory");
            }
            return new JsonResult("File Upload Failed");
        }

        public JsonResult OnPostEdit(CatalogItemEditRequestViewmodel request)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new JsonResult(new BaseDto<int>(false, allErrors.Select(p => p.ErrorMessage).ToList(), 0));
            }

            var model = new CatalogItemEditRequestDto();

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
                //CatalogItem.CatalogItemImages = images;
                model.AddedImages = images;
            }


            model.Price = request.Price;
            model.Description = request.Description;
            model.AvailableStock = request.AvailableStock;
            model.CatalogBrandId = request.CatalogBrandId;
            model.CatalogTypeId = request.CatalogTypeId;
            model.ReStockThreshold = request.ReStockThreshold;
            model.MaxStockThreshold = request.MaxStockThreshold;
            model.Id = request.Id;
            model.Name = request.Name;
            model.AddedFeatures = request.AddedFeatures;
            model.RemovedFeatures = request.RemovedFeatures;
            model.RemovedImages = request.RemovedImages;



            //var resultService = mapper.Map<CatalogItemsDto>(CatalogItem);
            var resultService = catalogItemService.Edit(model);
            return new JsonResult(resultService);
        }
    }
}
