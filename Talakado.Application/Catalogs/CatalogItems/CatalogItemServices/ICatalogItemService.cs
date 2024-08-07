using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MongoDB.Driver.Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Application.Dtos;
using Talakado.Application.UriComposer;
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
        //

        void AddToMyFavorite(string UserId, int CatalogItemId);
        PaginatedItemDto<FavoriteCatalogItemDto> GetMyFavorite(string UserId, int page = 1, int pageSize = 20);
    }

    public class CatalogItemService : ICatalogItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        private readonly IUriComposerService uriComposerService;

        public CatalogItemService(IDataBaseContext context, IMapper mapper, IUriComposerService uriComposerService)
        {
            this.context = context;
            this.mapper = mapper;
            this.uriComposerService = uriComposerService;
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
                catalogItem.CatalogItemImages = context.CatalogItemImage.Where(c=>c.CatalogItemId == id && (EF.Property<bool>(c, "IsRemoved") == false)).ToList();
                catalogItem.CatalogItemFeatures = context.CatalogItemFeature.Where(c => c.CatalogItemId == id && (EF.Property<bool>(c, "IsRemoved") == false)).ToList();
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

            #region Edit Catalog Item Fields
            catalogItem.Name = request.Name;
            catalogItem.Price = request.Price;
            catalogItem.CatalogBrandId = request.CatalogBrandId;
            catalogItem.CatalogTypeId = request.CatalogTypeId;
            catalogItem.AvailableStock = request.AvailableStock;
            catalogItem.MaxStockThreshold = request.MaxStockThreshold;
            catalogItem.ReStockThreshold = request.MaxStockThreshold;
            catalogItem.Description = request.Description;
            #endregion

            #region Add Image
            if (request.AddedImages != null && request.AddedImages.Count > 0)
            {
                foreach (var item in request.AddedImages)
                {
                    //catalogItem.CatalogItemImages.Add(new CatalogItemImage()
                    //{
                    //    CatalogItemId = request.Id,
                    //    CatalogItem = catalogItem,
                    //    Src = (item.Src != null)? item.Src : "no src"
                    //});
                    context.CatalogItemImage.Add(new CatalogItemImage
                    {
                        CatalogItem = catalogItem,
                        CatalogItemId = request.Id,
                        Src = (item.Src != null) ? item.Src : "no src"
                    });
                }
            }
            #endregion

            #region Add Feature
            if (request.AddedFeatures != null && request.AddedFeatures.Length > 0)
            {
                foreach (var item in request.AddedFeatures)
                {
                    context.CatalogItemFeature.Add(new CatalogItemFeature()
                    {
                        CatalogItem = catalogItem,
                        CatalogItemId = request.Id,
                        Group = item[0],
                        Key = item[1],
                        Value = item[2]
                    });
                }
            }
            #endregion

            #region Remove Feature

            if (request.RemovedFeatures != null && request.RemovedFeatures.Length > 0)
            {
                for (int i = 0; i < request.RemovedFeatures.Length; i++)
                {
                    string feature = request.RemovedFeatures[i];
                    if (feature == null || string.IsNullOrEmpty(feature)) continue;
                    var featureRecord = context.CatalogItemFeature.SingleOrDefault(c => c.Id == int.Parse(feature));
                    if (featureRecord != null)
                    {
                        context.CatalogItemFeature.Remove(featureRecord);
                        //catalogItem.CatalogItemFeatures.Remove(featureRecord);
                    }
                }
            }
            #endregion

            #region Remove Image
            if (request.RemovedImages != null && request.RemovedImages.Length > 0)
            {
                for (int i = 0; i < request.RemovedImages.Length; i++)
                {
                    string? image = request.RemovedImages[i];
                    if (image == null || image == "" || image == "''") continue;
                    var imageId = int.Parse(image.ToString());
                    var imageRecord = context.CatalogItemImage.SingleOrDefault(c=>c.Id == imageId);
                    if (imageRecord != null)
                    {
                        context.CatalogItemImage.Remove(imageRecord);
                        //remove image file physically
                        //catalogItem.CatalogItemImages.Remove(imageRecord);
                    }
                }
            }
            #endregion


            if (context.SaveChanges() > 0)
            {
                var model = mapper.Map<CatalogItemsDto>(catalogItem);
                return new BaseDto<CatalogItemsDto>(
                    true,
                    new List<string> { "ویرایش کاتالوگ آیتم با موفقیت انجام شد" },
                    model
                    );
            }
            return new BaseDto<CatalogItemsDto>(
                    false,
                    new List<string> { "متاسفانه ویرایش کاتالوگ آیتم انجام نشد" },
                    null
                    );
        }

        public void AddToMyFavorite(string UserId, int CatalogItemId)
        {
            var catalogItem = context.CatalogItems.Find(CatalogItemId);
            CatalogItemFavorite catalogItemFavorite = new CatalogItemFavorite
            {
                CatalogItem = catalogItem,
                UserId = UserId,
            };
            context.CatalogItemFavorites.Add(catalogItemFavorite);
            context.SaveChanges();
        }

        public PaginatedItemDto<FavoriteCatalogItemDto> GetMyFavorite(string UserId, int page = 1, int pageSize = 20)
        {
            var model = context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .Include(p => p.Discounts)
                .Include(p => p.CatalogItemFavorites)
                .Where(p => p.CatalogItemFavorites.Any(f => f.UserId == UserId))
                .OrderByDescending(p => p.Id)
                .AsQueryable();
            int rowCount = 0;
             
            var data = model.PagedResult(page, pageSize, out rowCount)
                .ToList()
                .Select(p => new FavoriteCatalogItemDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Rate = 4,
                    AvailableStock = p.AvailableStock,
                    Image = uriComposerService
                        .ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                }).ToList();
            return new PaginatedItemDto<FavoriteCatalogItemDto>(page, pageSize, rowCount, data);  
        }
    }

    public class FavoriteCatalogItemDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
        public int AvailableStock { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}

