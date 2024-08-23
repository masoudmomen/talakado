using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Talakado.Application.ContentManager;

namespace Talakado.AdminPanel.Pages.Content
{
    public class MainPageModel : PageModel
    {
        private readonly IContentManagerService contentManagerService;

        public MainPageModel(IContentManagerService contentManagerService)
        {
            this.contentManagerService = contentManagerService;
        }
        [BindProperty]
        public string? Phrase { get; set; }
        [BindProperty]
        public bool IsShow { get; set; } = false;
        public void OnGet()
        {
            var advertise = contentManagerService.GetAdvertisementPhraseForAdmin();
            if (advertise != null)
            {
                IsShow = advertise.IsShow;
                Phrase = advertise.Value;
            }
            else
            {
                Phrase = "";
                IsShow = false;
            }
            
            TempData["Page"] = 2;
        }

        public IActionResult OnPostSetAdvertismentPhrase(string phraseTxt, bool isShow) 
        {
            if (contentManagerService.AddAdvertisementPhrase(phraseTxt, isShow))
                return Content("true");
            return Content("false");
            //if(phrase == contentManagerService.GetAdvertisementPhrase("advertisementPhrase")) 
            //    return true;
            //return false;
        }
    }
}
