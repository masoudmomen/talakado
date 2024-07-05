using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Domain.Users;

namespace Talakado.Application.Users
{
    public interface IUserAddressService
    {
        List<UserAddressDto> GetAddress(string userId);
        void AddNewUserAddress(AddNewUserAddressDto addUserAddressDto);
    }

    public class UserAddressService : IUserAddressService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public UserAddressService(IDataBaseContext Context, IMapper mapper)
        {
            this.context = Context;
            this.mapper = mapper;
        }

        
        public void AddNewUserAddress(AddNewUserAddressDto addUserAddressDto)
        {
            var address = mapper.Map<UserAddress>(addUserAddressDto);
            context.UserAddresses.Add(address);
            context.SaveChanges();
        }

        public List<UserAddressDto> GetAddress(string UserId)
        {
            var address = context.UserAddresses.Where(p => p.UserId == UserId);
            var data = mapper.Map<List<UserAddressDto>>(address);
            return data;
        }
    }
    public class UserAddressDto
    {
        public string Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PostalAddress { get; set; }
        public string ReciverName { get; set; }
    }

    public class AddNewUserAddressDto
    {
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PostalAddress { get; set; }
        public string ReciverName { get; set; }
        public string UserId { get; set; }
    }
}
