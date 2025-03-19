using Basket.Host.Domain.Basket.DomainModels;

namespace Basket.Host.Domain.Basket
{
    public interface IBasketReadRepository
    {
        Task<UserBasket> GetUserBasket(int UserId);

        Task<UserBasketItem> GetUserBasketItem(int basketId, string Slug);

        Task<List<UserBasketItem>> GetUserBasketItems(string Slug);

        Task<UserBasketItem> GetUserBasketItem(int BasketItemId);
    }
}
