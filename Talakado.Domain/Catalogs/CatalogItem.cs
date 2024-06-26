﻿using Talakado.Domain.Attributes;

namespace Talakado.Domain.Catalogs
{
    [Auditable]
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set;}
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

        public ICollection<CatalogItemFeature> CatalogItemFeatures { get; set; }
        public ICollection<CatalogItemImage> CatalogItemImages { get; set; }
    }
}
