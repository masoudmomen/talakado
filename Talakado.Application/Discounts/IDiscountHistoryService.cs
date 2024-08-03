using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Application.Dtos;
using Talakado.Domain.Discounts;

namespace Talakado.Application.Discounts
{
    public interface IDiscountHistoryService
    {
        void InsertDiscountUsageHistory(int DiscountId, int OrderId);
        DiscountUsagehistory GetDiscountUsageHistoryById(int DiscountUsageHistoryId);
        PaginatedItemDto<DiscountUsagehistory> GetAllDiscountUsageHistory(int? discountId, string? userId, int pageIndex, int pageSize);
    }

    public class DiscountHistoryService : IDiscountHistoryService
    {
        private readonly IDataBaseContext context;

        public DiscountHistoryService(IDataBaseContext context)
        {
            this.context = context;
        }

        public PaginatedItemDto<DiscountUsagehistory> GetAllDiscountUsageHistory(int? discountId, string? userId, int pageIndex, int pageSize)
        {
            var query = context.DiscountUsagehistories.AsQueryable();

            if(discountId.HasValue && discountId.Value > 0) 
                query = query.Where(p=>p.DiscountId == discountId.Value);

            if(!string.IsNullOrWhiteSpace(userId))
                query = query.Where(p=>p.Order != null && p.Order.UserId == userId);

            query = query.OrderByDescending(p => p.CreatedOn);
            var pagedItems = query.PagedResult(pageIndex, pageSize, out int rowCount);
            return new PaginatedItemDto<DiscountUsagehistory>(pageIndex, pageSize, rowCount, query.ToList());
        }

        public DiscountUsagehistory GetDiscountUsageHistoryById(int DiscountUsageHistoryId)
        {
            if (DiscountUsageHistoryId == 0) return null;
            return context.DiscountUsagehistories.Find(DiscountUsageHistoryId);
        }

        public void InsertDiscountUsageHistory(int DiscountId, int OrderId)
        {
            var order = context.Orders.Find(OrderId);
            var discount = context.Discounts.Find(DiscountId);

            DiscountUsagehistory discountUsagehistory = new DiscountUsagehistory()
            {
                CreatedOn = DateTime.Now,
                Discount = discount,
                Order = order
            };
            context.DiscountUsagehistories.Add(discountUsagehistory);
            context.SaveChanges();
        }
    }
}
