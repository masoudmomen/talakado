using Talakado.Domain.Attributes;
using Talakado.Domain.Discounts;
using Talakado.Domain.Order;

namespace Talakado.Domain.Catalogs
{
    [Auditable]
    public class CatalogItem
    {
        private int _price = 0;
        private int? _oldPrice = null;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Price
        {
            get
            {
                return GetPrice();
            }
            set
            {
                Price = _price;
            }
        }
        public int? OldPrice 
        {
            get
            {
                return _oldPrice;
            }    
            set
            {
                OldPrice = _oldPrice;
            }
        }
        public int? PercentDiscount { get; set; }
        public int VisitCount { get; set; }
        public string Slug { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        /// <summary>
        /// موجودی انبار
        /// </summary>
        public int AvailableStock { get; set; }
        /// <summary>
        /// موجودی کمتر از این مقدار شد هشدار می دهد
        /// </summary>
        public int ReStockThreshold { get; set; }
        /// <summary>
        /// محدودیت قابل انبار کردن
        /// </summary>
        public int MaxStockThreshold { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<CatalogItemFeature> CatalogItemFeatures { get; set; }
        public ICollection<CatalogItemImage> CatalogItemImages { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<CatalogItemFavorite> CatalogItemFavorites { get; set; }

        private int GetPrice()
        {
            var dis = GetPreferredDiscount(Discounts, _price);
            if (dis != null)
            {
                var discountAmount = dis.GetDiscountAmount(_price);
                int newPrice = _price - discountAmount;
                _oldPrice = _price;
                PercentDiscount = (discountAmount * 100) / _price;
                return newPrice;
            }
            return _price;
        }
        public void SetPrice(int price)
        {
            _price = price;
        }
        /// <summary>
        /// دریافت بیشترین تخفیف
        /// </summary>
        /// <param name="discounts"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        private Discount GetPreferredDiscount(ICollection<Discount> discounts, int price)
        {
            Discount preferredDiscount = null;
            decimal? maximumDiscountValue = null;
            if (discounts != null)
            {
                foreach (var discount in discounts)
                {
                    var currentDiscountValue = discount.GetDiscountAmount(price);
                    if (currentDiscountValue != decimal.Zero)
                    {
                        if (!maximumDiscountValue.HasValue || currentDiscountValue > maximumDiscountValue)
                        {
                            maximumDiscountValue = currentDiscountValue;
                            preferredDiscount = discount;
                        }
                    }
                }
            }
            return preferredDiscount;
        }
    }
}