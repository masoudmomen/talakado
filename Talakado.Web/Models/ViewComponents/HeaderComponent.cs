using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talakado.Application.BasketsService;
using Talakado.Web.Utilities;

namespace Talakado.Web.Models.ViewComponents
{
    public class HeaderComponent : ViewComponent
    {
        private readonly IBasketService basketService;

        public HeaderComponent(IBasketService basketService)
        {
            this.basketService = basketService;
        }
        private ClaimsPrincipal userClaimPrincipal => ViewContext?.HttpContext?.User;
        public IViewComponentResult Invoke()
        {
            BasketDto basket = null;
            if (User.Identity.IsAuthenticated)
            {
                basket = basketService.GetBasketForUser(ClaimUtility.GetUserId(userClaimPrincipal));
            }
            else
            {
                string basketCookieName = "BasketId";
                if (Request.Cookies.ContainsKey(basketCookieName))
                {
                    var buyerId = Request.Cookies[basketCookieName];
                    basket=basketService.GetBasketForUser(buyerId);
                }
            }
            return View(viewName: "HeaderComponent", model: basket);
        }
    }
}
