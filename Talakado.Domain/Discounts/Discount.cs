using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Domain.Attributes;
using Talakado.Domain.Catalogs;

namespace Talakado.Domain.Discounts
{
    [Auditable]
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool UserPercentage { get; set; }
        public int DiscountPercentage { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool RequiredCouponCode { get; set; }
        public string CouponCode { get; set; }
        [NotMapped]
        public DiscountType DiscountType 
        {
            get => (DiscountType)this.DiscountTypeId;
            set => this.DiscountTypeId = (int)value;
        }
        public int DiscountTypeId { get; set; }
        public ICollection<CatalogItem> CatalogItems { get; set; }

        public int LimitationTimes { get; set; }
        public DiscountLimitationType DiscountLimitationType 
        {
            get => (DiscountLimitationType) this.DiscountLimitationId;
            set => this.DiscountLimitationId = (int)value;
        }
        public int DiscountLimitationId { get; set; }
    }

    public enum DiscountType
    {
        AssignedToProduct = 1,
        AssignedToCategory = 2,
        AssignedToUser = 3,
        AssignedToBrand = 4,
    }
    /// <summary>
    /// محدودیت تعداد استفاده
    /// </summary>
    public enum DiscountLimitationType
    {
        /// <summary>
        /// بدون محدودیت تعداد
        /// </summary>
        Unlimited = 0,
        /// <summary>
        /// فقط N بار
        /// </summary>
        NTimesOnly = 1,
        /// <summary>
        /// فقط N بار به ازای هر مشتری
        /// </summary>
        NTimesPerCustomer = 2,
    }
}
