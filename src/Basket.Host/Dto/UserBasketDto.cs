namespace Basket.Host.Dto
{
    public record UserBasketDto(string Slug, string ProductName, decimal Price, int UserId)
    {
    }
}
