using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;

namespace Talakado.Application.Catalogs.CatalogItemsFilter
{
    public interface IGetCatalogsPriceFilterService
    {
        List<PriceFilterDto> GetCatalogsPriceFilterList();
    }

    public class GetCatalogsPriceFilterService: IGetCatalogsPriceFilterService
    {
        private readonly IDataBaseContext context;

        public GetCatalogsPriceFilterService(IDataBaseContext context)
        {
            this.context = context;
        }

        public List<PriceFilterDto> GetCatalogsPriceFilterList()
        {
            //var minPrice = context.CatalogItems.Min(c=>c.Price);
            var minPrice = 0;
            var maxPrice = context.CatalogItems.Max(c=>c.Price);
            var domainPrice = (maxPrice - minPrice)/5;
            domainPrice = domainPrice - (domainPrice % 100000);
            var model = new List<PriceFilterDto>();
            for (var i = 0; i<5; i++)
            {
                model.Add(new PriceFilterDto
                {
                    MinPrice = minPrice,
                    MaxPrice = (i==4)?maxPrice : minPrice + domainPrice,
                });
                minPrice = minPrice + domainPrice;
            }

            foreach (var item in model)
            {
                item.Count = context.CatalogItems.Count(c => c.Price >= item.MinPrice && c.Price <= item.MaxPrice);
            }
            return model;
        }
    }
    public class PriceFilterDto
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int Count { get; set; }
    }
}
