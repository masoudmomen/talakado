﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Domain.Order
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public Address Address { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Order(string userId, Address address, List<OrderItem> orderItems, PaymentMethod paymentMethod)
        {
            UserId = userId;
            Address = address;
            _orderItems = orderItems;
            PaymentMethod = paymentMethod;
        }

        //For EF
        public Order()
        {
            
        }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int CatalogItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
        public int UnitPrice { get; private set; }
        public int Units { get; private set; }
        public OrderItem(int catalogItemId, string productName, string pictureUri, int unitPrice, int units)
        {
            this.CatalogItemId = catalogItemId;
            this.ProductName = productName;
            this.PictureUri = pictureUri;
            this.Units = units;
            this.UnitPrice = unitPrice;
        }
        //For EF
        public OrderItem()
        {
                
        }
    }
    public class Address
    {
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string ReciverName { get; private set; }
        public Address(string city, string state, string zipCode, string postalAddress)
        {
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.PostalAddress = postalAddress;
        }
    }

    public enum PaymentMethod
    {
        /// <summary>
        /// پرداخت آنلاین
        /// </summary>
        OnlinePayment = 0,
        /// <summary>
        /// پرداخت در محل
        /// </summary>
        PaymentOnTheSpot = 1,
    }
    public enum PaymentStatus
    {
        /// <summary>
        /// منتظر پرداخت
        /// </summary>
        WaitingForPayment = 0,
        /// <summary>
        /// پرداخت انجام شد
        /// </summary>
        Paid = 1,
    }
    public enum OrderStatus
    {
        /// <summary>
        /// در حال پردازش
        /// </summary>
        Proccessing = 0,
        /// <summary>
        /// تحویل داده شد
        /// </summary>
        Delivered = 1,
        /// <summary>
        /// مرجوعی
        /// </summary>
        Returned = 2,
        /// <summary>
        /// لغو شد
        /// </summary>
        Canceled = 3
    }
}
