using Microsoft.AspNetCore.Mvc;
using Talakado.Application.Catalogs.CatalogTypes;
using Talakado.Application.Catalogs.GetMenuItems;

namespace Talakado.Web.Models.ViewComponents
{
    public class GetMenuCategories:ViewComponent
    {
        private readonly IGetMenuItemService getMenuItemService;

        public GetMenuCategories(IGetMenuItemService getMenuItemService) 
        {
            this.getMenuItemService = getMenuItemService;
        }
        public IViewComponentResult Invoke()
        {
            var data = getMenuItemService.Execute();
            return View(viewName: "GetMenuCategories", model: data);
        }
    }
}
