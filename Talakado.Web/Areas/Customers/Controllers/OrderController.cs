using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Orders;

namespace Talakado.Web.Areas.Customers.Controllers
{
    [Area("Customers")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [Authorize]
        public IActionResult Index(int orderId = 0)
        {
            var data = orderService.GetOrderFromId(orderId);
            return View(data);
        }
    }
}
