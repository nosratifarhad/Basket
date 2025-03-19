using Basket.Host.Domain.Basket.Entities;

namespace Basket.Host.Domain.Basket
{
    public interface IBasketReadRepository
    {
        Task<UserBasket> GetUserBasket(int UserId);

        Task<List<UserBasket>> GetUserBaskets(IEnumerable<int> UserBasketIds);

        Task<UserBasketItem> GetUserBasketItem(int basketId, string Slug);

        Task<List<UserBasketItem>> GetUserBasketItems(string Slug);

        Task<UserBasketItem> GetUserBasketItem(int BasketItemId);
    }
}
