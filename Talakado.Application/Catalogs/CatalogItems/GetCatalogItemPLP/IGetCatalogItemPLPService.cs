using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Catalogs.CatalogItems.UriComposer;
using Talakado.Application.Contexts;
using Talakado.Application.Dtos;

namespace Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPLP
{
    public interface IGetCatalogItemPLPService
    {
        PaginatedItemDto<CatalogPLPDto> Execute(int pageNumber, int pageSize);
    }

    public class GetCatalogItemPLPService : IGetCatalogItemPLPService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposerService;

        public GetCatalogItemPLPService(IDataBaseContext context, IUriComposerService uriComposerService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
        }
        public PaginatedItemDto<CatalogPLPDto> Execute(int pageNumber, int pageSize)
        {
            int rowCount = 0;
            var data = context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .OrderByDescending(p => p.Id)
                .PagedResult(pageNumber, pageSize, out rowCount)
                .Select(p => new CatalogPLPDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Rate = 4,
                    Image = uriComposerService.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src)
                }).ToList();
            return new PaginatedItemDto<CatalogPLPDto>(pageNumber,pageSize,rowCount,data);
        }
    }

    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
    }
}
