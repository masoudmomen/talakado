using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Talakado.AdminPanel.ViewModels.Catalogs;
using Talakado.Application.Catalogs.CatalogTypes;

namespace Talakado.AdminPanel.Pages.CatalogType
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogTypeService catalogTypeService;
        private readonly IMapper mapper;

        public CreateModel(ICatalogTypeService catalogTypeService, IMapper mapper)
        {
            this.catalogTypeService = catalogTypeService;
            this.mapper = mapper;
        }
        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel { };
        public List<string> Message { get; set; }
        public void OnGet(int? parentId)
        {
            CatalogType.ParentCatalogTypeId = parentId;
            TempData["page"] = 7;
        }   

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var model = mapper.Map<CatalogTypeDto>(CatalogType);
            var result = catalogTypeService.Add(model);
            if (result.IsSuccess)
            {
                return RedirectToPage("index", new { parentId = CatalogType.ParentCatalogTypeId });
            }
            Message = result.Message;
            return Page();
        }
    }
}
