using AutoMapper;
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
        private readonly IMapper mapper;

        public MainPageModel(IContentManagerService contentManagerService, IImageUploadService imageUploadService, IMapper mapper)
        {
            this.contentManagerService = contentManagerService;
            this.imageUploadService = imageUploadService;
            this.mapper = mapper;
        }

        [BindProperty]
        public HomePageViewmodel HomePageViewmodel { get; set; } = new HomePageViewmodel();
        public IFormFile File { get; set; } 
        public void OnGet()
        {
            var model = contentManagerService.GetHomePageContent();
            HomePageViewmodel = mapper.Map<HomePageViewmodel>(model);

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
        public string AdvertisePhrase { get; set; }
        public bool IsShowAdvertisePhrase { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsShowPhoneNumber { get; set; }
        public SliderContent? Slide1 { get; set; }
        public SliderContent? Slide2 { get; set; }
        public SliderContent? Slide3 { get; set; }
    }

    public class UploadDto
    {
        public string Message { get; set; }
        public bool Status { get; set; } = true;
        public List<string> FileNameAddress { get; set; }
    }
}




