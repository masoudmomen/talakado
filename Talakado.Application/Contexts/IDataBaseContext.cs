using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Domain.Catalogs;
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
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
