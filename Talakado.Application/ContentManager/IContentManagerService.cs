using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Application.UriComposer;
using Talakado.Domain.Contents;

namespace Talakado.Application.ContentManager
{
    public interface IContentManagerService
    {
        bool AddAdvertisementPhrase(string phrase, bool isShow = true);
        Content? GetAdvertisementPhrase();
        bool AddPhoneNumber(string phoneNumber, bool isShow = true);
        Content? GetPhoneNumber();
        bool AddImage(string url, string key);
        HomePageDto? GetHomePageContent();
    }

    public class ContentManagerService : IContentManagerService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposerService;

        public ContentManagerService(IDataBaseContext context, IUriComposerService uriComposerService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
        }

        public bool AddAdvertisementPhrase(string phrase, bool isShow = true)
        {
            var advertise = context.Contents.SingleOrDefault(c => c.Key == "advertisementPhrase");
            if (advertise == null)
            {
                context.Contents.Add(new Domain.Contents.Content
                {
                    Key = "advertisementPhrase",
                    Value = phrase,
                    IsShow = isShow
                });
            }
            else
            {
                advertise.Value = phrase;
                advertise.IsShow = isShow;
            }
            return context.SaveChanges() > 0;
        }

        public bool AddImage(string url, string key)
        {
            var image = context.Contents.SingleOrDefault(c=>c.Key == key);
            if (image == null)
            {
                context.Contents.Add(new Content 
                { 
                    IsShow = true,
                    Key = key,
                    Value = url
                });
                return context.SaveChanges() > 0;
            }
            image.Value = url;
            return context.SaveChanges() > 0;
        }

        public bool AddPhoneNumber(string phoneNumber, bool isShow = true)
        {
            var phoneNumberResult = context.Contents.SingleOrDefault(c => c.Key == "phoneNumber");
            if (phoneNumberResult == null)
            {
                context.Contents.Add(new Content
                {
                    Key = "phoneNumber",
                    Value = phoneNumber,
                    IsShow = isShow
                });
            }
            else
            {
                phoneNumberResult.Value = phoneNumber;
                phoneNumberResult.IsShow = isShow;
            }
            return context.SaveChanges() > 0;
        }
        public Content? GetAdvertisementPhrase()
        {
            var advertise = context.Contents.FirstOrDefault(c => c.Key == "advertisementPhrase");
            if (advertise != null)
                return advertise;
            return null;
        }

        public HomePageDto? GetHomePageContent()
        {
            var model = new HomePageDto();
            var slide1 = context.Contents.FirstOrDefault(c => c.Key == "slide1")?.Value;
            var slide2 = context.Contents.FirstOrDefault(c => c.Key == "slide2")?.Value;
            var slide3 = context.Contents.FirstOrDefault(c => c.Key == "slide3")?.Value;
            model.Slide1 = (slide1 != null) ? uriComposerService.ComposeImageUri(slide1) : "";
            model.Slide2 = (slide2 != null) ? uriComposerService.ComposeImageUri(slide2) : "";
            model.Slide3 = (slide3 != null) ? uriComposerService.ComposeImageUri(slide3) : "";
            return model;
        }

        public Content? GetPhoneNumber()
        {
            var phoneNumberResult = context.Contents.FirstOrDefault(c => c.Key == "phoneNumber");
            if (phoneNumberResult != null)
                return phoneNumberResult;
            return null;
        }
    }
}
