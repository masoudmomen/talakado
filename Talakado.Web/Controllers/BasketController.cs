using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.BasketsService;
using Talakado.Application.Orders;
using Talakado.Application.Payments;
using Talakado.Application.Users;
using Talakado.Domain.Order;
using Talakado.Domain.Users;
using Talakado.Web.Models.Basket;
using Talakado.Web.Utilities;

namespace Talakado.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly SignInManager<User> signInManager;
        private readonly IUserAddressService userAddressService;
        private readonly IOrderService orderService;
        private readonly IPaymentService paymentService;
        private string userId = null;

        public BasketController(IBasketService basketService,
            SignInManager<User> signInManager,
            IUserAddressService userAddressService
            ,IOrderService orderService
            ,IPaymentService paymentService)
        {
            this.basketService = basketService;
            this.signInManager = signInManager;
            this.userAddressService = userAddressService;
            this.orderService = orderService;
            this.paymentService = paymentService;
        }
        public IActionResult Index()
        {
            var data = GetOrSetBasket();
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(int CatalogItemId, int quantity=1)
        {
            var basket = GetOrSetBasket();
            basketService.AddItemToBasket(basket.Id, CatalogItemId, quantity);



            return RedirectToAction(nameof(Index));
        }

        private BasketDto GetOrSetBasket()
        {
            if (signInManager.IsSignedIn(User))
            {
                userId = ClaimUtility.GetUserId(User); 
                return basketService.GetOrCreateBasketForUser(userId);
            }
            else
            {
                SetCookiesForBasket();
                return basketService.GetOrCreateBasketForUser(userId);
            }
        }

        private void SetCookiesForBasket()
        {
            string basketCookieName = "BasketId";
            if (Request.Cookies.ContainsKey(basketCookieName))
            {
                userId = Request.Cookies[basketCookieName];
            }
            if (userId != null) return;
            userId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddDays(2);
            Response.Cookies.Append(basketCookieName, userId, cookieOptions);
        }

        [Authorize]
        public IActionResult ShipingPayment()
        {
            var userId = ClaimUtility.GetUserId(User);
            var data = new ShipinigPaymentViewmodel
            {
                UserAddresses = userAddressService.GetAddress(userId),
                Basket = basketService.GetBasketForUser(userId),
            };
            return View(data);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ShipingPayment(int Address, PaymentMethod PaymentMethod)
        {
            string userId = ClaimUtility.GetUserId(User);
            var basket = basketService.GetBasketForUser(userId);
            int orderId = orderService.CreateOrder(basket.Id,Address,PaymentMethod);    
            if (PaymentMethod == PaymentMethod.OnlinePayment)
            {
                //ثبت پرداخت
                var payment = paymentService.PayForOrder(orderId);
                // ارسال به درگاه پرداخت
                return RedirectToAction("Index", "Pay", new { PaymentId = payment.PaymentId });
            }
            else
            {
                //برو به صفحه سفارشات من
                return RedirectToAction("Index", "Orders", new { area = "customers" });
            }
        }

        public IActionResult Checkout()
        {
            var userId = ClaimUtility.GetUserId(User);
            var data = new ShipinigPaymentViewmodel
            {
                Basket = basketService.GetBasketForUser(userId),
            };
            return View(data);
        }
    }
}
