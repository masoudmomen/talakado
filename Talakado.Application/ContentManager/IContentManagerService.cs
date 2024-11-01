﻿using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Application.UriComposer;
using Talakado.Domain.Catalogs;
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
        bool SetTextContent(string Key, string Value, bool IsShow = true);
        bool SetBannerContent(string bannerLocation, string itemId, string bannerTxt);
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
            var slide1 = context.Contents.FirstOrDefault(c => c.Key == "slide1")?.Value;
            var slide2 = context.Contents.FirstOrDefault(c => c.Key == "slide2")?.Value;
            var slide3 = context.Contents.FirstOrDefault(c => c.Key == "slide3")?.Value;
            var banner = context.Contents.FirstOrDefault(c => c.Key == "bannerImage")?.Value;

            CatalogItem? bannerCatalogTR = null;
            if (context.Contents.FirstOrDefault(c => c.Key == "bannerItem-banner-tr") != null)
            {
                var bannerCatalogId = context.Contents.First(d => d.Key == "bannerItem-banner-tr").Value;
                var catalogId = int.Parse(bannerCatalogId);
                bannerCatalogTR = context.CatalogItems.FirstOrDefault(c => c.Id == catalogId);
                bannerCatalogTR.CatalogItemImages = context.CatalogItemImage.Where(c=>c.CatalogItemId == catalogId).ToList();
            }
            CatalogItem? bannerCatalogTL = null;
            if (context.Contents.FirstOrDefault(c => c.Key == "bannerItem-banner-tl") != null)
            {
                var bannerCatalogId = context.Contents.First(d => d.Key == "bannerItem-banner-tl").Value;
                var catalogId = int.Parse(bannerCatalogId);
                bannerCatalogTL = context.CatalogItems.FirstOrDefault(c => c.Id == catalogId);
            }
            CatalogItem? bannerCatalogBR = null;
            if (context.Contents.FirstOrDefault(c => c.Key == "bannerItem-banner-br") != null)
            {
                var bannerCatalogId = context.Contents.First(d => d.Key == "bannerItem-banner-br").Value;
                var catalogId = int.Parse(bannerCatalogId);
                bannerCatalogBR = context.CatalogItems.FirstOrDefault(c => c.Id == catalogId);
            }
            CatalogItem? bannerCatalogBL = null;
            if (context.Contents.FirstOrDefault(c => c.Key == "bannerItem-banner-bl") != null)
            {
                var bannerCatalogId = context.Contents.First(d => d.Key == "bannerItem-banner-bl").Value;
                var catalogId = int.Parse(bannerCatalogId);
                bannerCatalogBL = context.CatalogItems.FirstOrDefault(c => c.Id == catalogId);
            }
            var model = new HomePageDto()
            {
                Slide1 = new SliderContent
                {
                    ImageAddress = (slide1 != null) ? uriComposerService.ComposeImageUri(slide1) : "",
                    SlideText = (context.Contents.FirstOrDefault(c => c.Key == "slide1Text")?.Value) ?? ""
                },
                Slide2 = new SliderContent
                {
                    ImageAddress = (slide2 != null) ? uriComposerService.ComposeImageUri(slide2) : "",
                    SlideText = (context.Contents.FirstOrDefault(c => c.Key == "slide2Text")?.Value) ?? ""
                },
                Slide3 = new SliderContent
                {
                    ImageAddress = (slide3 != null) ? uriComposerService.ComposeImageUri(slide3) : "",
                    SlideText = (context.Contents.FirstOrDefault(c => c.Key == "slide3Text")?.Value) ?? ""
                },
                AdvertisePhrase = (context.Contents.FirstOrDefault(c => c.Key == "advertisementPhrase")?.Value) ?? "",
                IsShowAdvertisePhrase = (context.Contents.FirstOrDefault(c => c.Key == "advertisementPhrase")?.IsShow)??true,
                PhoneNumber = (context.Contents.FirstOrDefault(c => c.Key == "phoneNumber")?.Value) ?? "",
                IsShowPhoneNumber = (context.Contents.FirstOrDefault(c => c.Key == "phoneNumber")?.IsShow) ?? true,
                BannerImage = (banner != null) ? uriComposerService.ComposeImageUri(banner) : "",
                CatalogTypes = context.CatalogTypes.Where(c=>c.ParentCatalogTypeId == null).Select(c=> new CatalogTypeForHomePageDto
                {
                    Id = c.Id,
                    Name = c.Type,
                    ImageAddress = uriComposerService.ComposeImageUri(c.ImageAddress),
                    ItemCount = context.CatalogItems.Count(d=>d.CatalogTypeId == c.Id)
                }).ToList(),
                BannerTR = new BannerContent{
                     Text = context.Contents.FirstOrDefault(c=>c.Key == "bannerText-banner-tr")?.Value,
                     CatalogItem = bannerCatalogTR
                },
                BannerTL = new BannerContent
                {
                    Text = context.Contents.FirstOrDefault(c => c.Key == "bannerText-banner-tl")?.Value,
                    CatalogItem = bannerCatalogTL
                },
                BannerBR = new BannerContent
                {
                    Text = context.Contents.FirstOrDefault(c => c.Key == "bannerText-banner-br")?.Value,
                    CatalogItem = bannerCatalogBR
                },
                BannerBL = new BannerContent
                {
                    Text = context.Contents.FirstOrDefault(c => c.Key == "bannerText-banner-bl")?.Value,
                    CatalogItem = bannerCatalogBL
                },
            };
            return model;
        }

        public Content? GetPhoneNumber()
        {
            var phoneNumberResult = context.Contents.FirstOrDefault(c => c.Key == "phoneNumber");
            if (phoneNumberResult != null)
                return phoneNumberResult;
            return null;
        }

        public bool SetTextContent(string Key, string Value, bool IsShow = true)
        {
            var result = context.Contents.SingleOrDefault(c => c.Key == Key);
            if (result == null)
            {
                context.Contents.Add(new Content
                {
                    Key = Key,
                    Value = Value,
                    IsShow = IsShow
                });
            }
            else
            {
                result.Value = Value;
                result.IsShow = IsShow;
            }
            return context.SaveChanges() > 0;
        }

        public bool SetBannerContent(string bannerLocation, string itemId, string bannerTxt)
        {
            var bannerCatalogItem = "bannerItem-" + bannerLocation;
            var bannerText = "bannerText-" + bannerLocation;

            var result = context.Contents.SingleOrDefault(c => c.Key == bannerCatalogItem);
            if (result == null)
            {
                context.Contents.Add(new Content
                {
                    Key = bannerCatalogItem,
                    Value = itemId,
                    IsShow = true
                });
            }
            else
            {
                result.Value = itemId;
                result.IsShow = true;
            }

            var result1 = context.Contents.SingleOrDefault(c => c.Key == bannerText);
            if (result1 == null)
            {
                context.Contents.Add(new Content
                {
                    Key = bannerText,
                    Value = bannerTxt,
                    IsShow = true
                });
            }
            else
            {
                result1.Value = bannerTxt;
                result1.IsShow = true;
            }
            return context.SaveChanges() > 0;
        }

    }
}


