using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPLP;

namespace Talakado.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPService getCatalogItemPLPService;

        public ProductController(IGetCatalogItemPLPService getCatalogItemPLPService)
        {
            this.getCatalogItemPLPService = getCatalogItemPLPService;
        }
        public IActionResult Index(int page =1, int pageSize=20)
        {
            var data = getCatalogItemPLPService.Execute(page, pageSize);  
            return View(data);
        }
    }
}
