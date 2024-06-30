using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Catalogs.CatalogItems.UriComposer;
using Talakado.Application.Contexts;
using Talakado.Domain.Basket;

namespace Talakado.Application.BasketsService
{
    public interface IBasketService
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
        void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1);
    }
    public class BasketService : IBasketService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposerService;

        public BasketService(IDataBaseContext context, IUriComposerService uriComposerService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
        }

        public void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1)
        {
            var basket = context.Baskets.FirstOrDefault(p=>p.Id == basketId);
            if (basket == null)
                throw new Exception("");

            var catalog = context.CatalogItems.Find(catalogItemId);
            basket.AddItem(catalogItemId, quantity, catalog.Price);
            context.SaveChanges();
        }

        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var basket = context.Baskets
                .Include(p=>p.Items)
                .ThenInclude(p=>p.CatalogItem)
                .ThenInclude(p=>p.CatalogItemImages)
                .SingleOrDefault(p => p.BuyerId == BuyerId);
            if (basket == null)
            {
                // create basket
                return CreateBasketForUser(BuyerId);
            }
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    CatalogItemId = item.CatalogItemId,
                    Id = item.Id,
                    CatalogName = item.CatalogItem.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    ImageUrl = uriComposerService.ComposeImageUri(item?.CatalogItem?.CatalogItemImages?.FirstOrDefault()?.Src ?? "")
                }).ToList()
            };
        }

        private BasketDto CreateBasketForUser(string BuyerId)
        {
            Basket basket = new Basket(BuyerId);
            context.Baskets.Add(basket);
            context.SaveChanges();
            return new BasketDto
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id
            };
        }
    }
    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }

    public class BasketItemDto
    {
        public int Id { get; set; }
        public int CatalogItemId { get; set; }
        public string CatalogName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
