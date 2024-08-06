using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Talakado.Domain.Attributes;
using Talakado.Domain.Catalogs;
using Talakado.Domain.Discounts;

namespace Talakado.Domain.Basket
{
    [Auditable]
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; private set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();

        public int DiscountAmount { get; private set; } = 0;
        public Discount AppliedDiscount { get; private set; }
        public int? AppliedDiscountId { get; private set; }

        public ICollection<BasketItem> Items => _items.AsReadOnly();
        public Basket(string buyerId)
        {
            this.BuyerId = buyerId;      
        }

        public void AddItem(int catalogItemId, int quantity, int unitPrice)
        {
            if (!Items.Any(c=>c.CatalogItemId == catalogItemId))
            {
                _items.Add(new BasketItem(catalogItemId, quantity, unitPrice));
                return;
            }
            var existingItem = Items.FirstOrDefault(c=>c.CatalogItemId == catalogItemId);
            existingItem.AddQuantity(quantity);
        }

        public int TotalPrice()
        {
            int totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
            totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
            return totalPrice;
        }

        public int TotalPriceWithoutDiscount()
        {
            int totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
            return totalPrice;
        }

        public void ApplyDiscountCode(Discount discount)
        {
            if (discount != null)
            {
                this.AppliedDiscount = discount;
                this.AppliedDiscountId = discount.Id;
                this.DiscountAmount = discount.GetDiscountAmount(TotalPriceWithoutDiscount());
            }
        }

        public void RemoveDiscount()
        {
            AppliedDiscount = null;
            AppliedDiscountId = null;
            DiscountAmount = 0;
        }
    }

    [Auditable]
    public class BasketItem
    {
        public int Id { get; set; }
        public int UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int CatalogItemId { get; private set; }
        public CatalogItem CatalogItem { get; private  set; }
        public int BasketId { get; private set; }
        public BasketItem(int catalogItemId, int quantity, int unitPrice)
        {
            CatalogItemId = catalogItemId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
