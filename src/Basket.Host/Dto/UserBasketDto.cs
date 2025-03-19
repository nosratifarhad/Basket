namespace Basket.Host.Dto
{
    public class UserBasketDto
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal VatAmount { get; set; }
        public ICollection<UserBasketItemDto> UserBasketItems { get; set; }
    }
}
