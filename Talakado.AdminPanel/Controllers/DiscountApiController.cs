using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Discounts;

namespace Talakado.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountApiController : ControllerBase
    {
        private readonly IDiscountService discountService;

        public DiscountApiController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }

        [HttpGet]
        [Route("SearchCatalogItem")]
        public async Task<JsonResult> SearchCatalogItem(string term="")
        {
            return new JsonResult(discountService.GetCatalogItems(term));
        }
    }
}
