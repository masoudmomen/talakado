using Talakado.Application.BasketsService;
using Talakado.Application.Users;

namespace Talakado.Web.Models.Basket
{
    public class ShipinigPaymentViewmodel
    {
        public BasketDto Basket { get; set; }
        public List<UserAddressDto> UserAddresses { get; set; }
    }
}
