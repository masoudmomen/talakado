using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talakado.Application.BasketsService;
using Talakado.Application.ContentManager;
using Talakado.Domain.Contents;
using Talakado.Web.Utilities;

namespace Talakado.Web.Models.ViewComponents
{
    public class HeaderComponent : ViewComponent
    {
        private readonly IBasketService basketService;
        private readonly IContentManagerService contentManagerService;

        public HeaderComponent(IBasketService basketService, IContentManagerService contentManagerService)
        {
            this.basketService = basketService;
            this.contentManagerService = contentManagerService;
        }
        private ClaimsPrincipal userClaimPrincipal => ViewContext?.HttpContext?.User;
        public IViewComponentResult Invoke()
        {
            var model = new HeaderDto();
            model.AdvertisePhrase = contentManagerService.GetAdvertisementPhrase().Value;
            model.PhoneNumber = contentManagerService.GetPhoneNumber();
            if (User.Identity.IsAuthenticated)
            {
                model.Basket = basketService.GetBasketForUser(ClaimUtility.GetUserId(userClaimPrincipal));
            }
            else
            {
                string basketCookieName = "BasketId";
                if (Request.Cookies.ContainsKey(basketCookieName))
                {
                    var buyerId = Request.Cookies[basketCookieName];
                    model.Basket = basketService.GetBasketForUser(buyerId);
                }
            }
            return View(viewName: "HeaderComponent", model: model);
        }
    }

    public class HeaderDto
    {
        public BasketDto Basket { get; set; }
        public string? AdvertisePhrase { get; set; }
        public Content? PhoneNumber { get; set; }
    }
}
