using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Application.UriComposer;
using Talakado.Domain.Basket;

namespace Talakado.Application.BasketsService
{
    public interface IBasketService
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
        void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1);
        BasketDto GetBasketForUser(string UserId);
        void TransferBasket(string anonymousId, string UserId);
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

        public BasketDto GetBasketForUser(string UserId)
        {
            var basket = context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.CatalogItem)
                .ThenInclude(p => p.CatalogItemImages)
                .SingleOrDefault(p => p.BuyerId == UserId);
            if (basket == null)
            {
                return null;
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

        public void TransferBasket(string anonymousId, string UserId)
        {
            var anonymousBasket = context.Baskets.SingleOrDefault(p=>p.BuyerId ==  anonymousId);
            if (anonymousBasket == null) return;
            var userBasket = context.Baskets.SingleOrDefault(p=>p.BuyerId == UserId);
            if (userBasket == null)
            {
                userBasket =  new Basket(UserId);
                context.Baskets.Add(userBasket);
            }
            foreach (var item in anonymousBasket.Items)
            {
                userBasket.AddItem(item.CatalogItemId, item.Quantity, item.UnitPrice);
            }
            context.Baskets.Remove(anonymousBasket);
            context.SaveChanges();
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
        public int Total()
        {
            if (Items.Count>0)
            {
                return Items.Sum(p => p.UnitPrice * p.Quantity);
            }
            return 0;
        }
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
