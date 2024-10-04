using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Talakado.Application.ContentManager;
using Talakado.Infrastructure.ExternalApi.ImageServer;

namespace Talakado.AdminPanel.Pages.Content
{
    public class MainPageModel : PageModel
    {
        private readonly IContentManagerService contentManagerService;
        private readonly IImageUploadService imageUploadService;

        public MainPageModel(IContentManagerService contentManagerService, IImageUploadService imageUploadService)
        {
            this.contentManagerService = contentManagerService;
            this.imageUploadService = imageUploadService;
        }

        [BindProperty]
        public HomePageViewmodel HomePageViewmodel { get; set; } = new HomePageViewmodel();
        public IFormFile File { get; set; } 
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

        public IActionResult OnPostSetContent(string key, string txt, bool isShow)
        {
            if (contentManagerService.SetTextContent(key, txt, isShow))
                return Content("true");
            return Content("false");
        }


        public IActionResult OnPostAddPhoneNumber(string phoneNumberTxt, bool isShow)
        {
            if (contentManagerService.AddPhoneNumber(phoneNumberTxt, isShow))
                return Content("true");
            return Content("false");
        }

        public async Task<IActionResult> OnPostAddImage()
        {
            var slideNumber = Request.Form["slideNumber"];
            if (File != null) File = null;
            File = (IFormFile)Request.Form.Files[0];
            if (File != null)
            {
                var result = await imageUploadService.UploadAsync(File);
                if (result != null && result.FileNameAddress.Count > 0 && !string.IsNullOrEmpty(slideNumber))
                {
                    var slideImage = contentManagerService.AddImage(result.FileNameAddress[0], slideNumber);
                    if (slideImage) return Content("true");
                }
                return Content("false");
            }
            return Content("false");
        }
    }

    public class HomePageViewmodel
    {
        public string? Phrase { get; set; }
        public bool IsShowPhrase { get; set; } = false;
        public string? PhoneNumber { get; set; }
        public bool IsShowPhoneNumber { get; set; } = false;
        public string Slide1Text { get; set; }
        public string Slide2Text { get; set; }
        public string Slide3Text { get; set; }
    }

    public class UploadDto
    {
        public string Message { get; set; }
        public bool Status { get; set; } = true;
        public List<string> FileNameAddress { get; set; }
    }
}




