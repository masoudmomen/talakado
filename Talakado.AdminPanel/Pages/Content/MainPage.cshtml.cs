using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Talakado.Application.Catalogs.CatalogItems.CatalogItemServices;
using Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Talakado.Application.ContentManager;
using Talakado.Application.Dtos;
using Talakado.Infrastructure.ExternalApi.ImageServer;

namespace Talakado.AdminPanel.Pages.Content
{
    public class MainPageModel : PageModel
    {
        private readonly IContentManagerService contentManagerService;
        private readonly IImageUploadService imageUploadService;
        private readonly IMapper mapper;
        private readonly IGetCatalogItemPLPService getCatalogItemPLPService;

        public MainPageModel(IContentManagerService contentManagerService,
            IImageUploadService imageUploadService,
            IMapper mapper,
            IGetCatalogItemPLPService getCatalogItemPLPService)
        {
            this.contentManagerService = contentManagerService;
            this.imageUploadService = imageUploadService;
            this.mapper = mapper;
            this.getCatalogItemPLPService = getCatalogItemPLPService;
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


        public IActionResult OnPostSetContent(string key, string txt, bool isShow)
        {
            if (contentManagerService.SetTextContent(key, txt, isShow))
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

        public JsonResult OnPostGetCatalogItemList()
        {
            var request = new CatalogPLPRequestDto();
            request.SearchKey = Request.Form["searchKey"];
            request.page = (Request.Form != null && Request.Form["page"] != "" && Request.Form["page"] != "undefined")?
                int.Parse(Request.Form["page"].ToString()) : 0;
            request.pageSize = (Request.Form != null && Request.Form["pageSize"] != "" && Request.Form["pageSize"] != "undefined") ?
                int.Parse(Request.Form["pageSize"].ToString()) : 0;

            var result = getCatalogItemPLPService.Execute(request);
            return new JsonResult(result);
        }

        public IActionResult OnPostSetBannerContent(string itemId, string bannerTxt, string bannerLocation)
        {
            if (contentManagerService.SetBannerContent(bannerLocation, itemId, bannerTxt))
                return Content("true");
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
        public string? BannerImage { get; set; }

    }

    public class UploadDto
    {
        public string Message { get; set; }
        public bool Status { get; set; } = true;
        public List<string> FileNameAddress { get; set; }
    }
}




