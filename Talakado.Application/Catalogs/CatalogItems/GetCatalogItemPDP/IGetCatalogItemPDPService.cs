using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Application.UriComposer;

namespace Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPDP
{
    public interface IGetCatalogItemPDPService
    {
        CatalogItemPDPDto Execute(int Id);
    }
    public class GetCatalogItemPDPService : IGetCatalogItemPDPService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposerService;

        public GetCatalogItemPDPService(IDataBaseContext context,IUriComposerService uriComposerService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
        }
        public CatalogItemPDPDto Execute(int Id)
        {
            var catalogItem = context.CatalogItems
                .Include(p => p.CatalogItemFeatures)
                .Include(p => p.CatalogItemImages)
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .Include(p => p.Discounts)
                .SingleOrDefault(p => p.Id == Id);

            var feature = catalogItem.CatalogItemFeatures
                .Select(p => new PDPFeaturesDto
                {
                    Group = p.Group,
                    Key = p.Key,
                    Value = p.Value
                }).ToList()
                .GroupBy(p => p.Group);

            var similarCatalogItems = context
                .CatalogItems
                .Include(p => p.CatalogItemFeatures)
                .Where(p => p.CatalogTypeId == catalogItem.CatalogTypeId)
                .Take(10)
                .Select(p => new SimilarCatalogItemDto
                {
                    Id = p.Id,
                    Images = uriComposerService.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                    Price = p.Price,
                    Name = p.Name,
                }).ToList();

            return new CatalogItemPDPDto
            {
                Features = feature,
                SimilarCatalogs=similarCatalogItems,
                Id=catalogItem.Id,
                Name=catalogItem.Name,
                Brand=catalogItem.CatalogBrand.Brand,
                Type=catalogItem.CatalogType.Type,
                Description=catalogItem.Description,
                Images = catalogItem.CatalogItemImages.Select(p => uriComposerService.ComposeImageUri(p.Src)).ToList(),
                Price = catalogItem.Price,
                OldPrice = catalogItem.OldPrice,
                PercentDiscount = catalogItem.PercentDiscount
            };
        }
    }

    public class CatalogItemPDPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int? OldPrice { get; set; }
        public int? PercentDiscount { get; set; }
        public List<string> Images { get; set; }
        public string Description { get; set; }
        public IEnumerable<IGrouping<string,PDPFeaturesDto>> Features { get; set; }
        public List<SimilarCatalogItemDto> SimilarCatalogs { get; set; }
    }

    public class PDPFeaturesDto
    {
        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class SimilarCatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Images { get; set; }
    }
}
