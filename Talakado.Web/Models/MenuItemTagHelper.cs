using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Talakado.Application.Catalogs.GetMenuItems;

namespace Talakado.Web.Models
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    //[HtmlTargetElement("tag-name")]
    public class MenuItemTagHelper : TagHelper
    {
        private readonly IGetMenuItemService getMenuItemService;

        public MenuItemTagHelper(IGetMenuItemService getMenuItemService)
        {
            this.getMenuItemService = getMenuItemService;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

        }
    }
}
