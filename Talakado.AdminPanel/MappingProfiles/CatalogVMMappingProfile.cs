using AutoMapper;
using Talakado.AdminPanel.Pages.Content;
using Talakado.AdminPanel.ViewModels.Catalogs;
using Talakado.Application.Catalogs.CatalogItems.CatalogItemServices;
using Talakado.Application.Catalogs.CatalogTypes;
using Talakado.Application.ContentManager;

namespace Talakado.AdminPanel.MappingProfiles
{
    public class CatalogVMMappingProfile:Profile
    {
        public CatalogVMMappingProfile()
        {
            CreateMap<CatalogTypeDto, CatalogTypeViewModel>().ReverseMap();
            CreateMap<CatalogItemsDto, CatalogItemViewModel>().ReverseMap();
            CreateMap<HomePageDto, HomePageViewmodel>().ReverseMap();
        }
    }
}
