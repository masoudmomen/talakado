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
        public HomePageViewmodel HomePageViewmodel { get; set; } = new HomePageViewmodel();

        public void OnGet()
        {
            var advertise = contentManagerService.GetAdvertisementPhrase();
            if (advertise != null)
            {
                HomePageViewmodel.IsShowPhrase = advertise.IsShow;
                HomePageViewmodel.Phrase = advertise.Value;
            }
            else
            {
                HomePageViewmodel.Phrase = "";
                HomePageViewmodel.IsShowPhrase = false;
            }

            var phoneNumber = contentManagerService.GetPhoneNumber();
            if (phoneNumber != null)
            {
                HomePageViewmodel.IsShowPhoneNumber = phoneNumber.IsShow;
                HomePageViewmodel.PhoneNumber = phoneNumber.Value;
            }
            else
            {
                HomePageViewmodel.PhoneNumber = "";
                HomePageViewmodel.IsShowPhoneNumber = false;
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


        public IActionResult onPostAddImage()
        {

        }
    }

    public class HomePageViewmodel
    {
        public string? Phrase { get; set; }
        public bool IsShowPhrase { get; set; } = false;
        public string? PhoneNumber { get; set; }
        public bool IsShowPhoneNumber { get; set; } = false;
    }
}
