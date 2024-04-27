using Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Talakado.Domain.Catalogs;

namespace Talakado.AdminPanel.ViewModels.Catalogs
{
    public class CatalogItemEditRequestViewmodel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }
        public int AvailableStock { get; set; }
        public int ReStockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public List<string>? RemovedImages { get; set; }
        public List<string>? RemovedFeatures { get; set; }
        public List<AddNewCatalogItemFeature_Dto>? CatalogItemFeatures { get; set; }
        public List<AddNewCatalogItemImage_Dto>? CatalogItemImages { get; set; }
    }
}
