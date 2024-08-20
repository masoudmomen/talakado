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
        public void OnGet()
        {
            Phrase = contentManagerService.GetAdvertisementPhrase();
            TempData["Page"] = 2;
        }

        public void OnPost(string phrase, bool isShow) 
        {
            contentManagerService.AddAdvertisementPhrase(phrase, isShow);
            //if(phrase == contentManagerService.GetAdvertisementPhrase("advertisementPhrase")) 
            //    return true;
            //return false;
        }
    }
}
