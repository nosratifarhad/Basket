﻿namespace Basket.Host.Domain.Basket.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal VatAmount { get; set; }

        public ICollection<BasketProduct> BasketProducts { get; set; }
    }
}
