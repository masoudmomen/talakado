using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Domain.Attributes;

namespace Talakado.Domain.Users
{
    [Auditable]
    public class UserAddress
    {
        public int Id { get; set; }
        public string State { get;private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string UserId { get; private set; }
        public string ReciverName { get; private set; }

        public UserAddress(string state, string city,string zipCode, string postalAddress, string userId, string reciverName)
        {
            this.State = state;
            this.City = city;
            this.ZipCode = zipCode;
            this.PostalAddress = postalAddress;
            this.UserId = userId;
            this.ReciverName = reciverName;
        }

        //For EF
        public UserAddress()
        {
                
        }
    }
}
