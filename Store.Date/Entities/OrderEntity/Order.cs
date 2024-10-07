﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Date.Entities.OrderEntity
{
    public class Order:BaseEntity<Guid>
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public ShippingAdress ShippingAdress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public int? DeliveyMethodId { get; set; }
        public IReadOnlyList<OrderItem>OrderItems { get; set; }
        public decimal SubTotal {  get; set; }
        public decimal GetTotal()
            => SubTotal + DeliveryMethod.Price;
        public string? BasketId { get; set; }
    }
}
