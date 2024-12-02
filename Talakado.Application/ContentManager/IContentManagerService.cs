using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Microsoft.EntityFrameworkCore;
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
        bool SetBannerContent(string bannerLocation, string itemId, string? bannerTxt);
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
            var slide1 = (context.Contents.FirstOrDefault(c => c.Key == "slide1") != null)?
                context.Contents.First(c => c.Key == "slide1").Value : null;
            var slide2 = (context.Contents.FirstOrDefault(c => c.Key == "slide2") != null)?
                context.Contents.First(c => c.Key == "slide2").Value : null;
            var slide3 = (context.Contents.FirstOrDefault(c => c.Key == "slide3") != null)?
                context.Contents.First(c => c.Key == "slide3").Value : null;
            var AfterSpecil = context.Contents.FirstOrDefault(c => c.Key == "bannerAfterSpecilLeft")?.Value;
            var AfterNewestLeft = context.Contents.FirstOrDefault(c => c.Key == "bannerAfterNewestCatalogsLeft")?.Value;
            var AfterNewestRight = context.Contents.FirstOrDefault(c => c.Key == "bannerAfterNewestCatalogsRight")?.Value;
            var banner = context.Contents.FirstOrDefault(c => c.Key == "bannerImage")?.Value;

            CatalogItem? bannerCatalogMid = new CatalogItem() { CatalogItemImages = new List<CatalogItemImage>() };
            bannerCatalogMid.CatalogItemImages.Add(new CatalogItemImage());
            if (context.Contents.FirstOrDefault(c => c.Key == "bannerItem-banner-mid") != null)
            {
                var bannerCatalogId = context.Contents.First(d => d.Key == "bannerItem-banner-mid").Value;
                var catalogId = int.Parse(bannerCatalogId);
                bannerCatalogMid = context.CatalogItems.Include(m => m.Discounts).Include(m => m.CatalogItemImages).FirstOrDefault(c => c.Id == catalogId);
                if (bannerCatalogMid.CatalogItemImages.Count() > 0)
                {
                    bannerCatalogMid.CatalogItemImages.First().Src = uriComposerService.ComposeImageUri(bannerCatalogMid.CatalogItemImages.First().Src);
                }
                else
                {
                    bannerCatalogMid.CatalogItemImages.Add(new CatalogItemImage
                    {
                        Src = "noSrc"
                    });
                }

            }

            CatalogItem? bannerCatalogTR = new CatalogItem() { CatalogItemImages = new List<CatalogItemImage>() };
            bannerCatalogTR.CatalogItemImages.Add(new CatalogItemImage());
            if (context.Contents.FirstOrDefault(c => c.Key == "bannerItem-banner-tr") != null)
            {
                var bannerCatalogId = context.Contents.First(d => d.Key == "bannerItem-banner-tr").Value;
                var catalogId = int.Parse(bannerCatalogId);
                bannerCatalogTR = context.CatalogItems.Include(m=>m.Discounts).Include(m=>m.CatalogItemImages).FirstOrDefault(c => c.Id == catalogId);
                if(bannerCatalogTR.CatalogItemImages.Count() > 0)
                {
                    bannerCatalogTR.CatalogItemImages.First().Src = uriComposerService.ComposeImageUri(bannerCatalogTR.CatalogItemImages.First().Src);
                }
                else
                {
                    bannerCatalogTR.CatalogItemImages.Add(new CatalogItemImage
                    {
                        Src = "noSrc"
                    });
                }
                
            }
            CatalogItem? bannerCatalogTL = new CatalogItem() { CatalogItemImages = new List<CatalogItemImage>() };
            bannerCatalogTL.CatalogItemImages.Add(new CatalogItemImage());
            if (context.Contents.FirstOrDefault(c => c.Key == "bannerItem-banner-tl") != null)
            {
                var bannerCatalogId = context.Contents.First(d => d.Key == "bannerItem-banner-tl").Value;
                var catalogId = int.Parse(bannerCatalogId);
                bannerCatalogTL = context.CatalogItems.Include(m => m.Discounts).Include(m => m.CatalogItemImages).FirstOrDefault(c => c.Id == catalogId);
                if (bannerCatalogTL.CatalogItemImages.Count() > 0)
                {
                    bannerCatalogTL.CatalogItemImages.First().Src = uriComposerService.ComposeImageUri(bannerCatalogTL.CatalogItemImages.First().Src);
                }
                else
                {
                    bannerCatalogTL.CatalogItemImages.Add(new CatalogItemImage
                    {
                        Src = "noSrc"
                    });
                }
            }
            CatalogItem? bannerCatalogBR = new CatalogItem() { CatalogItemImages = new List<CatalogItemImage>() };
            bannerCatalogBR.CatalogItemImages.Add(new CatalogItemImage());
            if (context.Contents.FirstOrDefault(c => c.Key == "bannerItem-banner-br") != null)
            {
                var bannerCatalogId = context.Contents.First(d => d.Key == "bannerItem-banner-br").Value;
                var catalogId = int.Parse(bannerCatalogId);
                bannerCatalogBR = context.CatalogItems.Include(m => m.Discounts).Include(m => m.CatalogItemImages).FirstOrDefault(c => c.Id == catalogId);
                if (bannerCatalogBR.CatalogItemImages.Count() > 0)
                {
                    bannerCatalogBR.CatalogItemImages.First().Src = uriComposerService.ComposeImageUri(bannerCatalogBR.CatalogItemImages.First().Src);
                }
                else
                {
                    bannerCatalogBR.CatalogItemImages.Add(new CatalogItemImage
                    {
                        Src = "noSrc"
                    });
                }
            }
            CatalogItem? bannerCatalogBL = new CatalogItem() { CatalogItemImages = new List<CatalogItemImage>() };
            bannerCatalogBL.CatalogItemImages.Add(new CatalogItemImage());
            if (context.Contents.FirstOrDefault(c => c.Key == "bannerItem-banner-bl") != null)
            {
                var bannerCatalogId = context.Contents.First(d => d.Key == "bannerItem-banner-bl").Value;
                var catalogId = int.Parse(bannerCatalogId);
                bannerCatalogBL = context.CatalogItems.Include(m => m.Discounts).Include(m => m.CatalogItemImages).FirstOrDefault(c => c.Id == catalogId);
                if (bannerCatalogBL.CatalogItemImages.Count() > 0)
                {
                    bannerCatalogBL.CatalogItemImages.First().Src = uriComposerService.ComposeImageUri(bannerCatalogBL.CatalogItemImages.First().Src);
                }
                else
                {
                    bannerCatalogBL.CatalogItemImages.Add(new CatalogItemImage
                    {
                        Src = "noSrc"
                    });
                }
            }
            CatalogItem bannerCatalogAfterSpecil = new CatalogItem() { CatalogItemImages = new List<CatalogItemImage>() };
            bannerCatalogAfterSpecil.CatalogItemImages.Add(new CatalogItemImage());
            if (context.Contents.FirstOrDefault(c => c.Key == "bannerItem-banner-afterSpecil") != null)
            {
                var bannerCatalogId = context.Contents.First(d => d.Key == "bannerItem-banner-afterSpecil").Value;
                var catalogId = int.Parse(bannerCatalogId);
                bannerCatalogAfterSpecil = context.CatalogItems.Include(m => m.Discounts).Include(m => m.CatalogItemImages).First(c => c.Id == catalogId);
                if (bannerCatalogAfterSpecil.CatalogItemImages.Count() > 0)
                {
                    bannerCatalogAfterSpecil.CatalogItemImages.First().Src = uriComposerService.ComposeImageUri(bannerCatalogAfterSpecil.CatalogItemImages.First().Src);
                }
                else
                {
                    bannerCatalogAfterSpecil.CatalogItemImages.Add(new CatalogItemImage
                    {
                        Src = "noSrc"
                    });
                }
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
                BannerMid = new BannerContent
                {
                    Text = context.Contents.FirstOrDefault(c => c.Key == "bannerText-banner-mid")?.Value,
                    CatalogItem = bannerCatalogMid
                },
                BannerAfterSpecil = new BannerContent
                {
                    Text = context.Contents.FirstOrDefault(c => c.Key == "bannerText-banner-afterSpecil")?.Value,
                    CatalogItem = bannerCatalogAfterSpecil
                },
                SpecialCatalogs = context.CatalogItems
                    .Include(c=>c.CatalogItemImages)
                    .Include(c=>c.CatalogItemFeatures)
                    .Where(c=>c.IsSpecialProduct == true).OrderByDescending(c=>c.CatalogTypeId).ToList(),
                SlideAfterSpecil = new SliderContent
                {
                    ImageAddress = (AfterSpecil != null) ? uriComposerService.ComposeImageUri(AfterSpecil) : "",
                    SlideText = (context.Contents.FirstOrDefault(c => c.Key == "bannerAfterSpecilLefttxt")?.Value) ?? ""
                },
                NewestCatalogs = context.CatalogItems
                .Include(c=>c.CatalogItemImages)
                .Include (c=>c.Discounts)
                .Take(1).OrderBy(c=>c.CatalogTypeId).ToList(),
                SlideAfterNewestCatalogsLeft = new SliderContent
                {
                    ImageAddress = (AfterNewestLeft != null) ? uriComposerService.ComposeImageUri(AfterNewestLeft) : "",
                    SlideText = (context.Contents.FirstOrDefault(c => c.Key == "bannerAfterNewestCatalogsLefttxt")?.Value) ?? ""
                },
                SlideAfterNewestCatalogsRight = new SliderContent
                {
                    ImageAddress = (AfterNewestRight != null) ? uriComposerService.ComposeImageUri(AfterNewestRight) : "",
                    SlideText = (context.Contents.FirstOrDefault(c => c.Key == "bannerAfterNewestCatalogsRighttxt")?.Value) ?? ""
                },
                BestSellerCatalogs = context.CatalogItems
                .Include(c => c.CatalogItemImages)
                .Include(c => c.Discounts)
                .Include(c=>c.OrderItems)
                .OrderByDescending(c=>c.OrderItems.Count).Take(5).ToList(),
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

        public bool SetBannerContent(string bannerLocation, string itemId, string? bannerTxt)
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


