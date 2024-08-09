using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Orders;
using Talakado.Application.Orders.CustomerOrderServices;
using Talakado.Domain.Users;

namespace Talakado.Web.Areas.Customers.Controllers
{
    [Area("Customers")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICustomerOrderService customerOrderService;
        private readonly UserManager<User> userManager;

        public OrderController(IOrderService orderService, ICustomerOrderService customerOrderService, UserManager<User> userManager)
        {
            this.orderService = orderService;
            this.customerOrderService = customerOrderService;
            this.userManager = userManager;
        }
       
        public IActionResult Index()
        {
            var data = orderService.GetOrders();
            return View(data);
        }

        public IActionResult OrderList()
        {
            var user = userManager.GetUserAsync(User).Result;
            var orders = customerOrderService.GetMyOrders(user.Id);
            return View(orders);
        }
    }
}
