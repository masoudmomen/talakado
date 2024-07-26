using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public bool UserPercentage { get; set; }
        public int DiscountPercentage { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool RequiredCouponCode { get; set; }
        public string CouponCode { get; set; }
        public int DiscountTypeId { get; set; }
        public int LimitationTimes { get; set; } = 0;
        public int DiscountLimitationId { get; set; }
        public List<int> AppliedToCatalogItem { get; set; }
    }
}
