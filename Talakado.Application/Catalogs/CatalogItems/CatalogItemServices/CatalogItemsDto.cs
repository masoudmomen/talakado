using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Domain.Catalogs;

namespace Talakado.Application.Catalogs.CatalogItems.CatalogItemServices
{
    public class CatalogItemsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        public int AvailableStock { get; set; }
        public int ReStockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }

        public string[]? RemovedImages { get; set; }
        public string[]? RemovedFeatures { get; set; }
        public ICollection<CatalogItemFeature> CatalogItemFeatures { get; set; }
        public ICollection<CatalogItemImage> CatalogItemImages { get; set; }
    }
}
