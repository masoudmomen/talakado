﻿using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Application.Dtos;
using Talakado.Application.UriComposer;

namespace Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPLP
{
    public interface IGetCatalogItemPLPService
    {
        PaginatedItemDto<CatalogPLPDto> Execute(CatalogPLPRequestDto request);
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
        public PaginatedItemDto<CatalogPLPDto> Execute(CatalogPLPRequestDto request)
        {
            int rowCount = 0;
            var query = context.CatalogItems
                .Include(p => p.Discounts)
                .Include(p => p.CatalogItemImages)
                .Include(p => p.CatalogBrand)
                .Include(p=>p.CatalogType)
                .OrderByDescending(p => p.Id)
                .AsQueryable();
            // Apply Filter :
            if(request.BrandId != null)
            {
                query = query.Where(p => request.BrandId.Any(b => b == p.CatalogBrandId));
            }
            if (request.CatalogeTypeId != null)
            {
                query = query.Where(p => p.CatalogTypeId == request.CatalogeTypeId);
            }
            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                query = query.Where(p => p.Name.Contains(request.SearchKey)
                || p.Description.Contains(request.SearchKey));
            }
            if (request.AvailableStock == true)
            {
                query = query.Where(p=>p.AvailableStock > 0);
            }
            if (request.SortType == SortType.BestSelling)
            {
                query = query.Include(p => p.OrderItems)
                    .OrderByDescending(p => p.OrderItems.Count);
            }
            if (request.SortType == SortType.MostPopular)
            {
                query = query.OrderByDescending(p => p.VisitCount);
            }
            if (request.SortType == SortType.Newest)
            {
                query = query.OrderByDescending(p => p.Id);
            }
            if (request.SortType == SortType.Cheapest)
            {
                query = query.Include(p => p.Discounts)
                    .OrderBy(p => p.Price);
            }
            if (request.SortType == SortType.MostExpensive)
            {
                query = query.Include(p => p.Discounts)
                    .OrderByDescending(p => p.Price);
            }

            var data = query.PagedResult(request.page, request.pageSize, out rowCount)
            .Select(p => new CatalogPLPDto
            {
                Id = p.Id,
                Name = p.Name,
                Slug = p.Slug,
                Price = p.Price,
                Rate = 4,
                Image = uriComposerService.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                Brand = p.CatalogBrand.Brand,
                Description = p.Description,
                OldPrice = p.OldPrice,
                PercentDiscount = p.PercentDiscount,
                Type = p.CatalogType.Type,
                AvailableStock = p.AvailableStock,
            }).ToList();
            return new PaginatedItemDto<CatalogPLPDto>(request.page, request.pageSize, rowCount,data);
        }
    }

    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int? OldPrice { get; set; }
        public int? PercentDiscount { get; set; }
        public string Description { get; set; }
        public int AvailableStock { get; set; }

    }


    public class CatalogPLPRequestDto
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 20;

        public int? CatalogeTypeId { get; set; }
        public int[]? BrandId { get; set; }
        public string? SearchKey { get; set; }
        public bool AvailableStock { get; set; }
        public SortType SortType { get; set; }
    }

    public enum SortType
    {
        /// <summary>
        /// بدون مرتب سازی
        /// </summary>
        None = 0,
        /// <summary>
        /// پر بازدیدترین
        /// </summary>
        Mostvisited = 1,
        /// <summary>
        /// پر فروش ترین
        /// </summary>
        BestSelling = 2,
        /// <summary>
        /// محبوب ترین
        /// </summary>
        MostPopular = 3,
        /// <summary>
        /// جدید ترین
        /// </summary>
        Newest = 4,
        /// <summary>
        /// ارزان ترین
        /// </summary>
        Cheapest = 5,
        /// <summary>
        /// گران ترین
        /// </summary>
        MostExpensive = 6,
    }
}
