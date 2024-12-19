using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Talakado.Application.ContentManager;
using Talakado.Application.UriComposer;
using Talakado.Infrastructure.CacheHelpers;
using Talakado.Web.Models;
using Talakado.Web.Models.Home;
using Talakado.Web.Utilities.Filters;

namespace Talakado.Web.Controllers
{
    [ServiceFilter(typeof(SaveVisitorFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDistributedCache cache;
        private readonly IContentManagerService contentManagerService;
        private readonly IMapper mapper;
        private readonly IUriComposerService uriComposerService;
        private readonly IPersonelManager personelManager;

        public HomeController(ILogger<HomeController> logger, 
            IDistributedCache cache,
            IContentManagerService contentManagerService, 
            IMapper mapper,
            IUriComposerService uriComposerService,
            IPersonelManager personelManager)
        {
            _logger = logger;
            this.cache = cache;
            this.contentManagerService = contentManagerService;
            this.mapper = mapper;
            this.uriComposerService = uriComposerService;
            this.personelManager = personelManager;
        }

        public IActionResult Index()
        {
            #region Caching 
            //HomePageDto homePageData = new HomePageDto()
            //var homePageCache = cache.GetAsync(CacheHelper.GenerateHomePageCacheKey());
            //if (homePageCache != null)
            //{
            //    homePageData = JsonSerializer.Deserialize<HomePageDto>(homePageCache);
            //}
            //else
            //{
            //    homePageData = homePageService.GerData();
            //    string jsonData = JsonSerializer.Serialize(homePageData);
            //    byte[] encodedJson = Encoding.UTF8.GetBytes(jsonData);
            //    var options = new DistributedCacheEntryExtensions()
            //        .SetAbsoluteExpiration(CacheHelper.DefaultCacheDuration);

            //    cache.SetAsync(CacheHelper.GenerateHomePageCacheKey(), encodedJson, options);
            //}
            //return View(homePageData);
            #endregion

            var result = contentManagerService.GetHomePageContent();
            var model = mapper.Map<HomePageViewmodel>(result);
            model.Personels = personelManager.GetPersonelsList();
            return View(model);
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Store()
        {
            return View();
        }
    }
}
