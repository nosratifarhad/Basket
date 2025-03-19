namespace Basket.Host.Dto
{
    public class IncreaseQuantityDto
    {
        public int UserBasketItemId { get; set; }
        public int UserId { get; set; }
    }
}
