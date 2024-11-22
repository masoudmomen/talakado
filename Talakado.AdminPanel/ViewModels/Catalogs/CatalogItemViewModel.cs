using System.ComponentModel;
using Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Talakado.Domain.Catalogs;

namespace Talakado.AdminPanel.ViewModels.Catalogs
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }
        [DisplayName("نام کاتالوگ")]
        public string? Name { get; set; }
        [DisplayName("توضیحات")]
        public string? Description { get; set; }
        [DisplayName("قیمت ")]
        public int Price { get; set; }
        public int CatalogTypeId { get; set; }
        [DisplayName("دسته بندی")]
        public CatalogType? CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        [DisplayName("برند ")]
        public CatalogBrand? CatalogBrand { get; set; }
        [DisplayName("تعداد موجودی")]
        public int AvailableStock { get; set; }
        [DisplayName("حداقل برای سفارش مجدد")]
        public int ReStockThreshold { get; set; }
        [DisplayName("حداکثر توان ذخیره در انبار")]
        public int MaxStockThreshold { get; set; }

        public List<AddNewCatalogItemFeature_Dto>? CatalogItemFeatures { get; set; }
        public List<AddNewCatalogItemImage_Dto>? CatalogItemImages { get; set; }

        public string[]? RemovedImages { get; set; }
        public string[]? RemovedFeatures { get; set; }
        public bool IsSpecialProduct { get; set; }
    }
}
