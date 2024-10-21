using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Talakado.AdminPanel.ViewModels.Catalogs;
using Talakado.Application.Catalogs.CatalogTypes;
using Talakado.Infrastructure.ExternalApi.ImageServer;

namespace Talakado.AdminPanel.Pages.CatalogType
{
    public class EditModel : PageModel
    {
        private readonly ICatalogTypeService catalogTypeService;
        private readonly IMapper mapper;
        private readonly IImageUploadService imageUploadService;

        public EditModel(ICatalogTypeService catalogTypeService, IMapper mapper, IImageUploadService imageUploadService)
        {
            this.catalogTypeService = catalogTypeService;
            this.mapper = mapper;
            this.imageUploadService = imageUploadService;
        }
        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel { };
        public IFormFile? File { get; set; }
        public List<string> Message { get; set; }
        
        public void OnGet(int Id)
        {
            var model = catalogTypeService.FindById(Id);
            if (model.IsSuccess)
            {
                CatalogType = mapper.Map<CatalogTypeViewModel>(model.Data);
            }
            Message = model.Message;
        }

        public async Task<IActionResult> OnPost()
        {
            if(string.IsNullOrEmpty(Request.Form["Id"]) || string.IsNullOrEmpty(Request.Form["name"]))
                return Content("خطا در دریافت اطلاعات");
            if (Request.Form["Id"] == "undefined" || Request.Form["name"] == "undefined")
                return Content("خطا در دریافت اطلاعات");

            #region Upload Image
            if (File != null) File = null;
            File = (Request.Form.Files.Count > 0) ? Request.Form.Files[0] : null;
            if (File != null)
            {
                var uploadResult = await imageUploadService.UploadAsync(File);
                if (uploadResult != null && uploadResult.FileNameAddress.Count > 0)
                {
                    CatalogType.ImageAddress = uploadResult.FileNameAddress[0];
                }
                else
                {
                    return Content("آپلود تصویر انجام نشد لطفا مجدد تلاش نمایید");
                }
            }
            #endregion

            int Id = int.Parse(Request.Form["Id"]);
            int? ParentCatalogTypeId = null;
            if (Request.Form["ParentCatalogTypeId"] != "undefined" && Request.Form["ParentCatalogTypeId"] != "")
            {
                ParentCatalogTypeId = int.Parse(Request.Form["ParentCatalogTypeId"]);
            }
            var model = new CatalogTypeDto
            {
                Id = Id,
                ParentCatalogTypeId = ParentCatalogTypeId,
                Type = Request.Form["name"].ToString(),
                ImageAddress = CatalogType.ImageAddress
            };
        
            var result = catalogTypeService.Edit(model);
            CatalogType = mapper.Map<CatalogTypeViewModel>(result.Data);
            if (result.IsSuccess) return Content("true");
            return Content(result.Message[0]);
        }
    }
}
