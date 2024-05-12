using Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Talakado.Domain.Catalogs;

namespace Talakado.AdminPanel.ViewModels.Catalogs
{
    public class CatalogItemEditRequestViewmodel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string CatalogTypeId { get; set; }
        public string CatalogBrandId { get; set; }
        public string AvailableStock { get; set; }
        public string ReStockThreshold { get; set; }
        public string MaxStockThreshold { get; set; }
        public string[]? RemovedImages { get; set; }
        public string[]? RemovedFeatures { get; set; }
        public string[]? AddedFeatures { get; set; }
        public List<IFormFile> AddedImages { get; set; }
    }
}
