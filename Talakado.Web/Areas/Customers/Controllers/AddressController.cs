using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Users;
using Talakado.Web.Models.User;
using Talakado.Web.Utilities;

namespace Talakado.Web.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class AddressController : Controller
    {
        private readonly IUserAddressService userAddressService;
        private readonly IMapper mapper;

        public AddressController(IUserAddressService userAddressService, IMapper mapper)
        {
            this.userAddressService = userAddressService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var addresses = userAddressService.GetAddress(ClaimUtility.GetUserId(this.User));
            return View(addresses);
        }

        public JsonResult Add(AddAddressModalDataViewmodel request)
        {
            if(request != null) 
            {
                var newAddress = new AddNewUserAddressDto
                {
                    City = request.City,
                    PostalAddress = request.PostalAddress,
                    ReciverName = request.ReciverName,
                    State = request.State,
                    ZipCode = request.ZipCode,
                    UserId = ClaimUtility.GetUserId(this.User),
                };
                userAddressService.AddNewUserAddress(newAddress);
                return Json(true);
            }
            return Json(false);
        }
    }
}
