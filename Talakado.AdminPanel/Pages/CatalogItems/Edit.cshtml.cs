using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Talakado.AdminPanel.ViewModels.Catalogs;
using Talakado.Application.Catalogs.CatalogItems.CatalogItemServices;

namespace Talakado.AdminPanel.Pages.CatalogItems
{
    public class EditModel : PageModel
    {
        private readonly ICatalogItemService catalogItemService;
        private readonly IMapper mapper;

        public EditModel(ICatalogItemService catalogItemService, IMapper mapper)
        {
            this.catalogItemService = catalogItemService;
            this.mapper = mapper;
        }
        [BindProperty]
        public CatalogItemViewModel CatalogItem { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Brands { get; set; }
        public List<string> Message { get; set; }
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

        public void OnPost()
        {
            var model = mapper.Map<CatalogItemsDto>(CatalogItem);

        }
    }
}
