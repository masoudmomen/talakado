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
        public IActionResult Index(int page =1, int pageSize=20)
        {
            var data = getCatalogItemPLPService.Execute(page, pageSize);  
            return View(data);
        }

        public IActionResult Details(int Id)
        {
            var data = getCatalogItemPDPService.Execute(Id);
            return View(data);
        }
    }
}
