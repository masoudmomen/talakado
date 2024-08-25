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
        public bool IsShowPhrase { get; set; } = false;

        [BindProperty]
        public string? PhoneNumber { get; set; }
        [BindProperty]
        public bool IsShowPhoneNumber { get; set; } = false;


        //[BindProperty]
        //HomePageViewmodel HomePageViewmodel { get; set; }

        public void OnGet()
        {
            var advertise = contentManagerService.GetAdvertisementPhrase();
            if (advertise != null)
            {
                IsShowPhrase = advertise.IsShow;
                Phrase = advertise.Value;
            }
            else
            {
                Phrase = "";
                IsShowPhrase = false;
            }

            var phoneNumber = contentManagerService.GetPhoneNumber();
            if (phoneNumber != null)
            {
                IsShowPhoneNumber = phoneNumber.IsShow;
                PhoneNumber = phoneNumber.Value;
            }
            else
            {
                PhoneNumber = "";
                IsShowPhoneNumber = false;
            }

            TempData["Page"] = 2;
        }

        public IActionResult OnPostSetAdvertismentPhrase(string phraseTxt, bool isShow) 
        {
            if (contentManagerService.AddAdvertisementPhrase(phraseTxt, isShow))
                return Content("true");
            return Content("false");
        }

        public IActionResult OnPostAddPhoneNumber(string phoneNumberTxt, bool isShow)
        {
            if (contentManagerService.AddPhoneNumber(phoneNumberTxt, isShow))
                return Content("true");
            return Content("false");
        }
    }

    //public class HomePageViewmodel 
    //{
    //    public string? Phrase { get; set; }
    //    public bool IsShowPhrase { get; set; } = false;
    //    public string? PhoneNumber { get; set; }
    //    public bool IsShowPhoneNumber { get; set; } = false;
    //}
}
