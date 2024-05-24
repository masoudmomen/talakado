using Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Talakado.Domain.Catalogs;

namespace Talakado.AdminPanel.ViewModels.Catalogs
{
    public class CatalogItemEditRequestViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }
        public int AvailableStock { get; set; }
        public int ReStockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public string[]? RemovedImages { get; set; }
        public string[]? RemovedFeatures { get; set; }
        public string[]? AddedFeatures { get; set; }
        //public string[]? AddedImages { get; set; }
    }
}
