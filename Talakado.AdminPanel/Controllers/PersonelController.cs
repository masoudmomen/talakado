using Microsoft.AspNetCore.Mvc;

namespace Talakado.AdminPanel.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
