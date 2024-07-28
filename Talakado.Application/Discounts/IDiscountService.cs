using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;

namespace Talakado.Application.Discounts
{
    public interface IDiscountService
    {
        List<CatalogItemDto> GetCatalogItems(string searchKey);
    }

    public class DiscountService : IDiscountService
    {
        private readonly IDataBaseContext context;

        public DiscountService(IDataBaseContext context)
        {
            this.context = context;
        }
        public List<CatalogItemDto> GetCatalogItems(string searchKey)
        {
            if (!string.IsNullOrEmpty(searchKey))
            {
                var data = context.CatalogItems.Where(p=>p.Name.Contains(searchKey))
                    .Select(p=> new CatalogItemDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }).ToList();
                return data;
            }
            else
            {
                var data = context.CatalogItems.OrderByDescending(p=>p.Id).Take(10)
                   .Select(p => new CatalogItemDto
                   {
                       Id = p.Id,
                       Name = p.Name,
                   }).ToList();
                return data;
            }
        }
    }

    public class CatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
