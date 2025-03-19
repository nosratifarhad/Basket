namespace Basket.Host.Subscription.PriceChanged
{
    public record PriceChangedEvent(string Slug, decimal Price);
}
