using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Application.Dtos;
using Talakado.Domain.Discounts;
using Talakado.Domain.Users;

namespace Talakado.Application.Discounts
{
    public interface IDiscountService
    {
        List<CatalogItemDto> GetCatalogItems(string searchKey);
        bool ApplyDiscountInBasket(string CopounCode, int BasketId);
        bool RemoveDiscountFromBasket(int BasketId);
        BaseDto IsDiscountValid(string couponCode, User user);
    }

    public class DiscountService : IDiscountService
    {
        private readonly IDataBaseContext context;
        private readonly IDiscountHistoryService discountHistoryService;

        public DiscountService(IDataBaseContext context, IDiscountHistoryService discountHistoryService)
        {
            this.context = context;
            this.discountHistoryService = discountHistoryService;
        }

        public bool ApplyDiscountInBasket(string CouponCode, int BasketId)
        {
            var basket = context.Baskets.Include(p=>p.Items).Include(p=>p.AppliedDiscount)
                .FirstOrDefault(p=>p.Id == BasketId);
            var discount = context.Discounts.Where(p => p.CouponCode.Equals(CouponCode)).FirstOrDefault();
            basket.ApplyDiscountCode(discount);
            context.SaveChanges();
            return true;
        }

        public List<CatalogItemDto> GetCatalogItems(string searchKey)
        {
            if (!string.IsNullOrEmpty(searchKey))
            {
                var data = context.CatalogItems.Where(p=>p.Name.Contains(searchKey))
                    .Select(p=> new CatalogItemDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }).ToList();
                return data;
            }
            else
            {
                var data = context.CatalogItems.OrderByDescending(p=>p.Id).Take(10)
                   .Select(p => new CatalogItemDto
                   {
                       Id = p.Id,
                       Name = p.Name,
                   }).ToList();
                return data;
            }
        }

        public bool RemoveDiscountFromBasket(int BasketId)
        {
            var basket = context.Baskets.Find(BasketId);
            basket.RemoveDiscount();
            context.SaveChanges();
            return true;
        }

        public BaseDto IsDiscountValid(string couponCode, User user)
        {
            var discount = context.Discounts.Where(p => p.CouponCode.Equals(couponCode)).FirstOrDefault();
            if (discount == null)
            {
                return new BaseDto(false, new List<string> { "کد تخفیف معتبر نمی باشد" });
            }
            var now = DateTime.Now;
            if (discount.StartDate.HasValue)
            {
                var startDate = DateTime.SpecifyKind(discount.StartDate.Value, DateTimeKind.Utc);
                if (startDate.CompareTo(now) > 0)
                {
                    return new BaseDto(false, new List<string> { "هنوز زمان استفاده از این کد تخفیف فرا نرسیده است" });
                }
            }
            if (discount.EndDate.HasValue)
            {
                var endDate = DateTime.SpecifyKind(discount.EndDate.Value, DateTimeKind.Utc);
                if (endDate.CompareTo(now) < 0)
                {
                    return new BaseDto(false, new List<string> { "کد تخفیف منقضی شده است" });
                }
            }

            var checkLimit = CheckDiscountLimitations(discount, user);
            if (checkLimit.IsSuccess == false)
                return checkLimit;
            return new BaseDto(true, null);
        }

        private BaseDto CheckDiscountLimitations(Discount discount, User user)
        {
            switch (discount.DiscountLimitationType)
            {
                case DiscountLimitationType.Unlimited:
                    {
                        return new BaseDto(true, null);
                    }
                case DiscountLimitationType.NTimesOnly:
                    {
                        var totalUsage = discountHistoryService.GetAllDiscountUsageHistory(discount.Id, null, 0, 1).Data.Count();
                        if (totalUsage < discount.LimitationTimes)
                        {
                            return new BaseDto(true, null);
                        }
                        else
                        {
                            return new BaseDto(false, new List<string> { "ظرفیت استفاده از این کد تخفیف تکمیل شده است" });
                        }
                    }
                case DiscountLimitationType.NTimesPerCustomer:
                    {
                        if (user != null)
                        {
                            var totalUsage = discountHistoryService.GetAllDiscountUsageHistory(discount.Id, user.Id, 0, 1).Data.Count();
                            if (totalUsage < discount.LimitationTimes)
                            {
                                return new BaseDto(true, null);
                            }
                            else
                            {
                                return new BaseDto(false, new List<string> { "ظرفیت استفاده از این کد تخفیف برای شما به پایان رسیده است" });
                            }
                        }
                        else
                        {
                            return new BaseDto(true, null);
                        }
                    }
                difault:
                    break;
            }
            return new BaseDto(true, null);
        }
    }

    public class CatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
