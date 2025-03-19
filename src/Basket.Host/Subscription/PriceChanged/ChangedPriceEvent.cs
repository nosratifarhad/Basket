namespace Basket.Host.Subscription.PriceChanged
{
    public record ChangedPriceEvent(string Slug, decimal Price);
}
