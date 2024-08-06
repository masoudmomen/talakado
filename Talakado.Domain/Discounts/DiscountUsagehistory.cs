using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Domain.Discounts
{
    public class DiscountUsagehistory
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Discount Discount { get; set; }
        public int DiscountId { get; set; }
        public virtual Order.Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
