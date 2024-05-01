using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Application.Dtos;
using Talakado.Domain.Catalogs;

namespace Talakado.Application.Catalogs.CatalogItems.CatalogItemServices
{
    public interface ICatalogItemService
    {
        List<CatalogBrandDto> GetBrand();
        List<ListCatalogTypeDto> GetCatalogType();
        PaginatedItemDto<CatalogItemListItemDto> GetCatalogList(int page, int pageSize);
        BaseDto<CatalogItemsDto> FindById(int id);
        BaseDto<CatalogItemsDto> Edit(CatalogItemsDto request);
    }

    public class CatalogItemService : ICatalogItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public CatalogItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<CatalogBrandDto> GetBrand()
        {
            var brands = context.CatalogBrands.OrderBy(p => p.Brand).Take(500).ToList();
            var data = mapper.Map<List<CatalogBrandDto>>(brands);
            return data;
        }

        public BaseDto<CatalogItemsDto> FindById(int id)
        {
            var catalogItem = context.CatalogItems.Find(id);
            if (catalogItem != null)
            {
                catalogItem.CatalogItemImages = context.CatalogItemImage.Where(c=>c.CatalogItemId == id).ToList();
                catalogItem.CatalogItemFeatures = context.CatalogItemFeature.Where(c => c.CatalogItemId == id).ToList();
            }
            var result = mapper.Map<CatalogItemsDto>(catalogItem);
            return new BaseDto<CatalogItemsDto>(true, null, result);
        }

        public PaginatedItemDto<CatalogItemListItemDto> GetCatalogList(int page, int pageSize)
        {
            int rowCount = 0;
            var data = context.CatalogItems
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .ToPaged(page, pageSize, out rowCount)
                .OrderByDescending(p => p.Id)
                .Select(p => new CatalogItemListItemDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Brand = p.CatalogBrand.Brand,
                    Type = p.CatalogType.Type,
                    AvailableStock = p.AvailableStock,
                    MaxStockThreshold = p.MaxStockThreshold,
                    ReStockThreshold = p.ReStockThreshold,
                }).ToList();

            return new PaginatedItemDto<CatalogItemListItemDto>(page, pageSize, rowCount, data);
        }

        public List<ListCatalogTypeDto> GetCatalogType()
        {
            var types = context.CatalogTypes
                .Include(p => p.ParentCatalogType)
                .Include(p => p.ParentCatalogType)
                .ThenInclude(p => p.ParentCatalogType.ParentCatalogType)
                .Include(p => p.SubType)
                .Where(p => p.ParentCatalogTypeId != null)
                .Where(p => p.SubType.Count == 0)
                .Select(p => new { p.Id, p.Type, p.ParentCatalogType, p.SubType }).ToList()
                .Select(p => new ListCatalogTypeDto()
                {
                    Id = p.Id,
                    Type = $"{p?.Type ?? ""} - {p?.ParentCatalogType?.Type ?? ""} - {p?.ParentCatalogType?.ParentCatalogType?.Type ?? ""}- {p?.ParentCatalogType?.ParentCatalogType?.ParentCatalogType?.Type ?? ""}"
                }).ToList();
            return types;
        }

         public BaseDto<CatalogItemsDto> Edit(CatalogItemsDto request)
        {
            var catalogItem = mapper.Map<CatalogItem>(request);
            context.CatalogItems.Add(catalogItem);
            if(request.RemovedFeatures != null && request.RemovedFeatures.Count() > 0)
            {
                foreach( var feature in request.RemovedFeatures)
                {
                    var featureRecord = context.CatalogItemFeature.SingleOrDefault(c=>c.Id == request.Id);
                    if (featureRecord != null) context.CatalogItemFeature.Remove(featureRecord);
                }
            }
            if (request.RemovedImages != null && request.RemovedImages.Count() > 0)
            {
                foreach (var image in request.RemovedImages)
                {
                    var imageRecord = context.CatalogItemImage.SingleOrDefault(c => c.Id == request.Id);
                    if (imageRecord != null)
                    {
                        context.CatalogItemImage.Remove(imageRecord);
                        // remove image file physically from the hard disk
                    }
                }
            }
            context.SaveChanges();
            return new BaseDto<CatalogItemsDto>(
                true,
                new List<string> { "ویرایش کاتالوگ آیتم با موفقیت انجام شد" },
                catalogItem
                );
                
        }
    }
}
