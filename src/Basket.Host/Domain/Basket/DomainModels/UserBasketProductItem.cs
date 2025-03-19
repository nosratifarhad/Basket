namespace Basket.Host.Domain.Basket.DomainModels
{
    public class UserBasketProductItem
    {
        public int Id { get; set; }

        public string Slug { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal? LatestPrice { get; set; }

        public bool UserChangedSeen { get; set; }

        public int Quantity { get; set; }

        public decimal? Discount { get; set; }

        public bool PriceChanged => LatestPrice.HasValue &&
                            LatestPrice.Value != Price;
    }
}
