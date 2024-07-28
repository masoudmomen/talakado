using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Domain.Catalogs;
using Talakado.Domain.Discounts;

namespace Talakado.Application.Discounts.AddNewDiscountService
{
    public interface IAddNewDiscountService
    {
        void Execute(AddNewDiscountDto discount);
    }

    public class AddNewDiscountService : IAddNewDiscountService
    {
        private readonly IDataBaseContext context;

        public AddNewDiscountService(IDataBaseContext context)
        {
            this.context = context;
        }
        public void Execute(AddNewDiscountDto discount)
        {
            var newDiscount = new Discount()
            {
                Name = discount.Name,
                CouponCode = discount.CouponCode,
                DiscountAmount = discount.DiscountAmount,
                DiscountLimitationId = discount.DiscountLimitationId,
                DiscountPercentage = discount.DiscountPercentage,
                DiscountTypeId = discount.DiscountTypeId,
                EndDate = discount.EndDate,
                StartDate = discount.StartDate,
                RequiredCouponCode = discount.RequiredCouponCode,
                UserPercentage = discount.UserPercentage,
            };

            if (discount.AppliedToCatalogItem != null)
            {
                var catalogItems = context.CatalogItems.Where(p => discount.AppliedToCatalogItem.Contains(p.Id)).ToList();
                newDiscount.CatalogItems = catalogItems;
            }

            context.Discounts.Add(newDiscount);
            context.SaveChanges();
        }
    }

    public class AddNewDiscountDto
    {
        [Display(Name ="نام تخفیف")]
        public string Name { get; set; }
        [Display(Name = "استفاده از درصد؟")]
        public bool UserPercentage { get; set; }
        [Display(Name = "درصد تخفیف")]
        public int DiscountPercentage { get; set; }
        [Display(Name = "مبلغ تخفیف")]
        public int DiscountAmount { get; set; }
        [Display(Name = "زمان شروع")]
        public DateTime StartDate { get; set; }
        [Display(Name = "زمان انقضا")]
        public DateTime EndDate { get; set; }
        [Display(Name = "استفاده از کوپن")]
        public bool RequiredCouponCode { get; set; }
        [Display(Name = "کد کوپن")]
        public string CouponCode { get; set; }
        [Display(Name = "نوع تخفیف")]
        public int DiscountTypeId { get; set; }
        [Display(Name = "تعداد کد تخفیف")]
        public int LimitationTimes { get; set; } = 0;
        [Display(Name = "محدودیت تخفیف")]
        public int DiscountLimitationId { get; set; }
        [Display(Name = "اعمال برای محصول")]
        public List<int> AppliedToCatalogItem { get; set; }
    }
}
