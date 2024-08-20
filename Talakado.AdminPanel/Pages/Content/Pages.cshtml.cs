using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Talakado.AdminPanel.Pages.Content
{
    public class PagesModel : PageModel
    {
        public void OnGet()
        {
            TempData["Page"] = 3;
        }
    }
}
