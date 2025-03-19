namespace Basket.Host.Domain.Basket.Entities
{
    public class UserBasket : BaseEntity
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal VatAmount { get; set; }
        public ICollection<UserBasketItem> UserBasketItems { get; set; }
    }
}
