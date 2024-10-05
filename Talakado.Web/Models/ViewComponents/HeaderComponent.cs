using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talakado.Application.BasketsService;
using Talakado.Application.Catalogs.CatalogTypes;
using Talakado.Application.ContentManager;
using Talakado.Application.Contexts;
using Talakado.Domain.Contents;
using Talakado.Web.Utilities;

namespace Talakado.Web.Models.ViewComponents
{
    public class HeaderComponent : ViewComponent
    {
        private readonly IBasketService basketService;
        private readonly IContentManagerService contentManagerService;
        private readonly ICatalogTypeService catalogTypeService;
        private readonly IIdentityDataBaseContext identityDataBaseContext;

        public HeaderComponent(IBasketService basketService, 
            IContentManagerService contentManagerService,
            ICatalogTypeService catalogTypeService,
            IIdentityDataBaseContext identityDataBaseContext)
        {
            this.basketService = basketService;
            this.contentManagerService = contentManagerService;
            this.catalogTypeService = catalogTypeService;
            this.identityDataBaseContext = identityDataBaseContext;
        }
        private ClaimsPrincipal userClaimPrincipal => ViewContext?.HttpContext?.User;
        public IViewComponentResult Invoke()
        {
            var model = new HeaderDto();
            model.AdvertisePhrase = contentManagerService.GetAdvertisementPhrase().Value;
            model.IsShowAdvertisePhrase = contentManagerService.GetAdvertisementPhrase().IsShow;
            model.PhoneNumber = contentManagerService.GetPhoneNumber();
            model.catalogTypeLists = catalogTypeService.GetList(null, 1, 100).Data.ToList();
            if (User.Identity.IsAuthenticated)
            {
                var userId = ClaimUtility.GetUserId(userClaimPrincipal);
                model.Basket = basketService.GetBasketForUser(userId);
                model.IsUserAuthenticated = true;
                model.UserFullName = identityDataBaseContext.Users.Find(userId)?.FullName;
            }
            else
            {
                model.IsUserAuthenticated= false;
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
        public bool IsShowAdvertisePhrase { get; set; }
        public Content? PhoneNumber { get; set; }
        public List<CatalogTypeListDto> catalogTypeLists { get; set; }
        public bool IsUserAuthenticated { get; set; }
        public string? UserFullName { get; set; }
    }
}
