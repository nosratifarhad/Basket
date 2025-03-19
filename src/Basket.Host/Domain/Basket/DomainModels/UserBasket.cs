namespace Basket.Host.Domain.Basket.DomainModels
{
    public class UserBasket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal VatAmount { get; set; }
    }
}
