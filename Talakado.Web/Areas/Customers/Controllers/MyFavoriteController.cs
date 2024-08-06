using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Catalogs.CatalogItems.CatalogItemServices;
using Talakado.Domain.Users;

namespace Talakado.Web.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class MyFavoriteController : Controller
    {
        private readonly ICatalogItemService catalogItemService;
        private readonly UserManager<User> userManager;
        
        public MyFavoriteController(ICatalogItemService catalogItemService, UserManager<User> userManager)
        {
            this.catalogItemService = catalogItemService;
            this.userManager = userManager;
        }
        public IActionResult Index(int page = 1, int pageSize = 20)
        {
            var user = userManager.GetUserAsync(User).Result;
            var data = catalogItemService.GetMyFavorite(user.Id, page, pageSize);
            return View(data);
        }

        public IActionResult AddToMyFavorite(int CatalogsItemId)
        {
            var user = userManager.GetUserAsync(User).Result; 
            catalogItemService.AddToMyFavorite(user.Id, CatalogsItemId);
            return RedirectToAction(nameof(Index));
        }
    }
}
