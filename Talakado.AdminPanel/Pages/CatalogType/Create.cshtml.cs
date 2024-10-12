using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public IFormFile File { get; set; }
        public List<string> Message { get; set; }
        public void OnGet(int? parentId)
        {
            CatalogType.ParentCatalogTypeId = parentId;
            TempData["page"] = 7;
        }   

        public async Task<IActionResult> OnPost()
        {
            var ParentCatalogTypeId = 0;
            CatalogType.Type = Request.Form["name"].ToString();
            if(!string.IsNullOrEmpty(Request.Form["ParentCatalogTypeId"].ToString()))
            {
                CatalogType.ParentCatalogTypeId = int.TryParse(Request.Form["ParentCatalogTypeId"].ToString(),);
            }
            
            if (File != null) File = null;
            File = (IFormFile)Request.Form.Files[0];
            if (File != null)
            {
                var uploadResult = await imageUploadService.UploadAsync(File);
                if (uploadResult != null && uploadResult.FileNameAddress.Count > 0)
                {
                    var model = mapper.Map<CatalogTypeDto>(CatalogType);
                    var result = catalogTypeService.Add(model);
                    if (result.IsSuccess)
                    {
                        return RedirectToPage("index", new { parentId = CatalogType.ParentCatalogTypeId });
                    }
                    Message = result.Message;
                }
                else 
                { 
                   
                    Message = new List<string> { "عملیات آپلود عکس با خطا مواجه شد"};
                }
            }
            else
            {
                var model = mapper.Map<CatalogTypeDto>(CatalogType);
                var result = catalogTypeService.Add(model);
                if (result.IsSuccess)
                {
                    return RedirectToPage("index", new { parentId = CatalogType.ParentCatalogTypeId });
                }
                Message = result.Message;
            }
            return Page();
        }
    }
}
