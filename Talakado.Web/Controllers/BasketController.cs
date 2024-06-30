using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.BasketsService;
using Talakado.Domain.Users;

namespace Talakado.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly SignInManager<User> signInManager;
        private string userId = null;

        public BasketController(IBasketService basketService, SignInManager<User> signInManager)
        {
            this.basketService = basketService;
            this.signInManager = signInManager;
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
                return basketService.GetOrCreateBasketForUser(User.Identity.Name);
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
    }
}
