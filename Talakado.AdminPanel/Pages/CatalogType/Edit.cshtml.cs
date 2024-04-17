using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Talakado.AdminPanel.ViewModels.Catalogs;
using Talakado.Application.Catalogs.CatalogTypes;

namespace Talakado.AdminPanel.Pages.CatalogType
{
    public class EditModel : PageModel
    {
        private readonly ICatalogTypeService catalogTypeService;
        private readonly IMapper mapper;

        public EditModel(ICatalogTypeService catalogTypeService, IMapper mapper )
        {
            this.catalogTypeService = catalogTypeService;
            this.mapper = mapper;
        }
        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel { };
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

        public IActionResult OnPost()
        {
            var model = mapper.Map<CatalogTypeDto>(CatalogType);
            var result = catalogTypeService.Edit(model);
            CatalogType = mapper.Map<CatalogTypeViewModel>(result.Data);
            Message = result.Message;
            return Page();
        }
    }
}
