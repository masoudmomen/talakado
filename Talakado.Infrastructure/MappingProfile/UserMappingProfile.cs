using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Users;
using Talakado.Domain.Order;
using Talakado.Domain.Users;

namespace Talakado.Infrastructure.MappingProfile
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserAddress, UserAddressDto>();
            CreateMap<AddNewUserAddressDto, UserAddress>();
            CreateMap<UserAddress, Address>();
        }
    }
}
