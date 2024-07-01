using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talakado.Application.BasketsService;
using Talakado.Web.Utilities;

namespace Talakado.Web.Models.ViewComponents
{
    public class BasketComponent: ViewComponent
    {
        private readonly IBasketService basketService;

        public BasketComponent(IBasketService basketService)
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
            }
        }
    }
}
