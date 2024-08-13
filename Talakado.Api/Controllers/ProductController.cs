using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPDP;
using Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPLP;

namespace Talakado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGetCatalogItemPLPService getCatalogItemPLPService;
        private readonly IGetCatalogItemPDPService getCatalogItemPDPService;

        public ProductController(IGetCatalogItemPLPService getCatalogItemPLPService, IGetCatalogItemPDPService getCatalogItemPDPService)
        {
            this.getCatalogItemPLPService = getCatalogItemPLPService;
            this.getCatalogItemPDPService = getCatalogItemPDPService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CatalogPLPRequestDto request)
        {
            return Ok(getCatalogItemPLPService.Execute(request));
        }
    }
}
