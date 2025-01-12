using Microsoft.AspNetCore.Mvc;
using Talakado.Application.BasketsService;
using Talakado.Application.Catalogs.CatalogItemsFilter;
using Talakado.Application.Catalogs.CatalogTypes;
using Talakado.Application.ContentManager;
using Talakado.Persistence.Contexts;
using Talakado.Web.Utilities;

namespace Talakado.Web.Models.ViewComponents
{
    public class PriceFilterComponent: ViewComponent
    {
        private readonly IGetCatalogsPriceFilterService getCatalogsPriceFilterService;

        public PriceFilterComponent(IGetCatalogsPriceFilterService getCatalogsPriceFilterService)
        {
            this.getCatalogsPriceFilterService = getCatalogsPriceFilterService;
        }
        public IViewComponentResult Invoke()
        {
            var model = getCatalogsPriceFilterService.GetCatalogsPriceFilterList();
            return View(viewName: "PriceFilterComponent", model: model);
        }
    }
}
