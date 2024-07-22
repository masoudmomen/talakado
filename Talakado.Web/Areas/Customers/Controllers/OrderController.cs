using Microsoft.AspNetCore.Mvc;

namespace Talakado.Web.Areas.Customers.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index(int orderId)
        {
             
            return View();
        }
    }
}
