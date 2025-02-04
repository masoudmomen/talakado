﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Domain.Basket;
using Talakado.Domain.Catalogs;
using Talakado.Domain.Contents;
using Talakado.Domain.Discounts;
using Talakado.Domain.Order;
using Talakado.Domain.Payments;
using Talakado.Domain.Personels;
using Talakado.Domain.Users;
using Talakado.Domain.Visitors;

namespace Talakado.Application.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<CatalogBrand> CatalogBrands { get; set; }
        DbSet<CatalogType> CatalogTypes { get; set; }
        DbSet<CatalogItem> CatalogItems { get; set; }
        DbSet<CatalogItemImage> CatalogItemImage { get; set; }
        DbSet<CatalogItemFeature> CatalogItemFeature { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<UserAddress> UserAddresses { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<DiscountUsagehistory> DiscountUsagehistories { get; set; }
        DbSet<CatalogItemFavorite> CatalogItemFavorites { get; set; }
        DbSet<Content> Contents { get; set; }
        DbSet<Personel> Personels { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry Entry(object entity);
    }
}
