using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Domain.Discounts;
using Talakado.Domain.Order;

namespace Talakado.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Address Address { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IReadOnlyCollection<OrderItem> OrderItems { get; set; }
        public int Price { get; set; }

    }
}
