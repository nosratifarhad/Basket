namespace Basket.Host.Dto
{
    public record CreateUserBasketDto(string Slug, string ProductName, decimal Price, int UserId)
    {
    }
}
