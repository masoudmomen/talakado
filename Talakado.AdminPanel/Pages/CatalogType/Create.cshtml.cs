using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Bson;
using Talakado.AdminPanel.ViewModels.Catalogs;
using Talakado.Application.Catalogs.CatalogTypes;
using Talakado.Application.ContentManager;
using Talakado.Infrastructure.ExternalApi.ImageServer;

namespace Talakado.AdminPanel.Pages.CatalogType
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogTypeService catalogTypeService;
        private readonly IMapper mapper;
        private readonly IImageUploadService imageUploadService;

        public CreateModel(ICatalogTypeService catalogTypeService, IMapper mapper, IImageUploadService imageUploadService)
        {
            this.catalogTypeService = catalogTypeService;
            this.mapper = mapper;
            this.imageUploadService = imageUploadService;
        }
        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel { };
        public IFormFile? File { get; set; }
        public List<string> Message { get; set; }
        public void OnGet(int? parentId)
        {
            CatalogType.ParentCatalogTypeId = parentId;
            TempData["page"] = 7;
        }   

        public async Task<IActionResult> OnPost()
        {
            CatalogType.Type = Request.Form["name"].ToString();
            string? parentCatalogtype = Request.Form["ParentCatalogTypeId"];
            if (parentCatalogtype != null && parentCatalogtype != "undefined" && parentCatalogtype != "")
            {
                CatalogType.ParentCatalogTypeId = int.Parse(parentCatalogtype);
            }
            
            if (File != null) File = null;
            File = (Request.Form.Files.Count>0)? Request.Form.Files[0] : null;
            if (File != null)
            {
                var uploadResult = await imageUploadService.UploadAsync(File);
                if (uploadResult != null && uploadResult.FileNameAddress.Count > 0)
                {
                    CatalogType.ImageAddress = uploadResult.FileNameAddress[0];
                }
                else 
                { 
                    return Content("false");
                }
            }
            var model = mapper.Map<CatalogTypeDto>(CatalogType);
            var result = catalogTypeService.Add(model);
            if (result.IsSuccess)
            {
                //return RedirectToPage("index", new { parentId = CatalogType.ParentCatalogTypeId });
                var parentId = CatalogType.ParentCatalogTypeId.ToString()??"";
                 return Content(parentId);
            }
            Message = result.Message;
            return Content("false");
        }
    }
}
