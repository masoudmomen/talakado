using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Domain.Attributes;
using Talakado.Domain.Basket;
using Talakado.Domain.Catalogs;
using Talakado.Domain.Order;
using Talakado.Domain.Payments;
using Talakado.Domain.Users;
using Talakado.Domain.Visitors;
using Talakado.Persistence.EntityConfigurations;
using Talakado.Persistence.Seeds;

namespace Talakado.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    builder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    builder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    builder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    builder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                }
            }

            //فقط کاتالوگ تایپ هایی که فیلد ایزریموود فالس هستند رو نمایش بده
            builder.Entity<CatalogType>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());

            DataBaseContextSeed.CatalogSeed(builder); //اجرای سیید

            builder.Entity<Order>().OwnsOne(p => p.Address); // باعث می شود تمامی فیلد های کلاس آدرس در همان اوردر ذخیره شوند و بابت آدرس جدول ساخته نشود

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                p.State == EntityState.Added ||
                p.State == EntityState.Deleted
                );
            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

                var inserted = entityType.FindProperty("InsertTime");
                var updated = entityType.FindProperty("UpdateTime");
                var RemoveTime = entityType.FindProperty("RemoveTime");
                var IsRemoved = entityType.FindProperty("IsRemoved");
                if (item.State == EntityState.Added && inserted != null)
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Modified && updated != null)
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Deleted && RemoveTime != null && IsRemoved != null)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemoved").CurrentValue = true;
                    item.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems{ get; set; }
        public DbSet<CatalogItemImage> CatalogItemImage { get; set; }
        public DbSet<CatalogItemFeature> CatalogItemFeature { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
