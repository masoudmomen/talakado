using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPDP;
using Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPLP;

namespace Talakado.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPService getCatalogItemPLPService;
        private readonly IGetCatalogItemPDPService getCatalogItemPDPService;

        public ProductController(IGetCatalogItemPLPService getCatalogItemPLPService, IGetCatalogItemPDPService getCatalogItemPDPService)
        {
            this.getCatalogItemPLPService = getCatalogItemPLPService;
            this.getCatalogItemPDPService = getCatalogItemPDPService;
        }
        public IActionResult Index(CatalogPLPRequestDto catalogPlpRequestDto)
        {
            var data = getCatalogItemPLPService.Execute(catalogPlpRequestDto);  
            return View(data);
        }

        public IActionResult Details(string Slug)
        {
            var data = getCatalogItemPDPService.Execute(Slug);
            return View(data);
        }
    }
}
