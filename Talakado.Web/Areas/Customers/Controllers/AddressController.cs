using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Users;
using Talakado.Web.Utilities;

namespace Talakado.Web.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class AddressController : Controller
    {
        private readonly IUserAddressService userAddressService;

        public AddressController(IUserAddressService userAddressService)
        {
            this.userAddressService = userAddressService;
        }
        public IActionResult Index()
        {
            var addresses = userAddressService.GetAddress(ClaimUtility.GetUserId(this.User));
            return View(addresses);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
