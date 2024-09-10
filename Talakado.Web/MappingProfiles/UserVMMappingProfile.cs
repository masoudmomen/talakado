using AutoMapper;
using Talakado.Web.Models;
using Talakado.Application.Catalogs.CatalogItems.CatalogItemServices;
using Talakado.Application.Catalogs.CatalogTypes;
using Talakado.Application.Users;
using Talakado.Web.Models.User;
using Talakado.Web.Models.Home;
using Talakado.Application.ContentManager;

namespace Talakado.AdminPanel.MappingProfiles
{
    public class UserVMMappingProfile : Profile
    {
        public UserVMMappingProfile()
        {
            CreateMap<AddAddressModalDataViewmodel, AddNewUserAddressDto>().ReverseMap();
            CreateMap<HomePageViewmodel, HomePageDto>().ReverseMap();

        }
    }
}
