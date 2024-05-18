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
using static System.Net.Mime.MediaTypeNames;

namespace Talakado.Application.Catalogs.CatalogItems.CatalogItemServices
{
    public interface ICatalogItemService
    {
        List<CatalogBrandDto> GetBrand();
        List<ListCatalogTypeDto> GetCatalogType();
        PaginatedItemDto<CatalogItemListItemDto> GetCatalogList(int page, int pageSize);
        BaseDto<CatalogItemsDto> FindById(int id);
        BaseDto<CatalogItemsDto> Edit(CatalogItemEditRequestDto request);
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

        public BaseDto<CatalogItemsDto> Edit(CatalogItemEditRequestDto request)
        {
            var catalogItem = context.CatalogItems.SingleOrDefault(p => p.Id == request.Id);
            if (catalogItem == null) return new BaseDto<CatalogItemsDto>(
                false,
                new List<string> { "کاتالوگ آیتم یافت نشد" },
                new CatalogItemsDto
                {
                    Id = request.Id,
                    Name = request.Name,
                    AvailableStock = request.AvailableStock,
                    CatalogBrandId = request.CatalogBrandId,
                    CatalogTypeId = request.CatalogTypeId,
                    Description = request.Description,
                    MaxStockThreshold = request.MaxStockThreshold,
                    Price = request.Price,
                    ReStockThreshold = request.ReStockThreshold,
                    CatalogItemFeatures = context.CatalogItemFeature.Where(c => c.CatalogItemId == request.Id).ToList(),
                    CatalogItemImages = context.CatalogItemImage.Where(c => c.CatalogItemId == request.Id).ToList(),
                    RemovedFeatures = request.RemovedFeatures,
                    RemovedImages = request.RemovedImages
                });
            //catalogItem.CatalogItemFeatures = context.CatalogItemFeature.Where(c => c.CatalogItemId == request.Id).ToList();
            //catalogItem.CatalogItemImages = context.CatalogItemImage.Where(c => c.CatalogItemId == request.Id).ToList();
            //mapper.Map(request, catalogItem);
            //context.SaveChanges();
            catalogItem.Name = request.Name;
            catalogItem.Price = request.Price;
            catalogItem.CatalogBrandId = request.CatalogBrandId;
            catalogItem.CatalogTypeId = request.CatalogTypeId;
            catalogItem.AvailableStock = request.AvailableStock;
            catalogItem.MaxStockThreshold = request.MaxStockThreshold;
            catalogItem.ReStockThreshold = request.MaxStockThreshold;
            catalogItem.Description = request.Description;

            if (request.AddedImages != null && request.AddedImages.Count > 0)
            {
                foreach (var item in request.AddedImages)
                {
                    catalogItem.CatalogItemImages.Add(new CatalogItemImage()
                    {
                        CatalogItemId = request.Id,
                        CatalogItem = catalogItem,
                        Src = item.Src
                    });
                }
            }
            if (request.AddedFeatures != null && request.AddedFeatures.Length > 0)
            {
                for (var i =0; i< request.AddedFeatures.Length; i++)
                {
                    catalogItem.CatalogItemFeatures.Add(new CatalogItemFeature()
                    {
                        CatalogItem = catalogItem,
                        CatalogItemId = request.Id,
                        Group = request.AddedFeatures[i][0],
                        Key = request.AddedFeatures[i][1],
                        Value = request.AddedFeatures[i][2]
                    });
                }
                //foreach (var item in request.AddedFeatures)
                //{
                //    catalogItem.CatalogItemFeatures.Add(new CatalogItemFeature()
                //    {
                //        CatalogItem = catalogItem,
                //        CatalogItemId = request.Id,
                //        Group = item[0],
                //        Key = item[1],
                //        Value = item[2]
                //    });
                //}
            }
            
            if (request.RemovedFeatures != null && request.RemovedFeatures.Length > 0)
            {
                for (int i = 0; i < request.RemovedFeatures.Length; i++)
                {
                    string? feature = request.RemovedFeatures[i];
                    if (feature == null) continue;
                    var featureRecord = context.CatalogItemFeature.SingleOrDefault(c=>c.Id == int.Parse(feature));
                    if (featureRecord != null)
                    {
                        context.CatalogItemFeature.Remove(featureRecord);
                        catalogItem.CatalogItemFeatures.Remove(featureRecord);
                    }
                }
            }
            if (request.RemovedImages != null && request.RemovedImages.Length > 0)
            {
                for (int i = 0; i < request.RemovedImages.Length; i++)
                {
                    string? image = request.RemovedImages[i];
                    if (image == null) continue;
                    var imageRecord = context.CatalogItemImage.SingleOrDefault(c=>c.Id == int.Parse(image));
                    if (imageRecord != null)
                    {
                        context.CatalogItemImage.Remove(imageRecord);
                        //remove image file physically
                        catalogItem.CatalogItemImages.Remove(imageRecord);
                    }
                }
            }
            context.SaveChanges();
            var model = mapper.Map<CatalogItemsDto>(catalogItem);
            return new BaseDto<CatalogItemsDto>(
                true,
                new List<string> { "ویرایش کاتالوگ آیتم با موفقیت انجام شد" },
                model
                );
                
        }
    }
}

