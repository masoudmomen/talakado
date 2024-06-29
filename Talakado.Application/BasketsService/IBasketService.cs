﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;

namespace Talakado.Application.BasketsService
{
    public interface IBasketService
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
    }
    public class BasketService : IBasketService
    {
        private readonly IDataBaseContext context;

        public BasketService(IDataBaseContext context)
        {
            this.context = context;
        }
        //public BasketDto GetOrCreateBasketForUser(string BuyerId)
        //{
        //    var basket = context.Baskets.SingleOrDefault(p)
        //}
    }
    public class BasketDto
    {
        public int BasketId { get; set; }
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
