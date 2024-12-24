using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Talakado.Application.ContentManager;

namespace Talakado.AdminPanel.Pages.Personels
{
    public class IndexModel : PageModel
    {
        private readonly IPersonelManager personelManager;

        public IndexModel(IPersonelManager personelManager)
        {
            this.personelManager = personelManager;
        }
        [BindProperty]
        public List<PersonelDto>? Personels { get; set; }
        public void OnGet()
        {
            Personels = personelManager.GetPersonelsList();         
            TempData["Page"] = 11;
        }
    }
}
