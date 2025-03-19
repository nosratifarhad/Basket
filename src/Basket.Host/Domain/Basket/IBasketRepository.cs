using Basket.Host.Domain.Basket.DomainModels;

namespace Basket.Host.Domain.Basket
{
    public interface IBasketRepository
    {
        Task<int> AddBasket(UserBasket basket);

        Task UpdateBasket(UserBasket basket);

        Task AddUserBasketProductItem(UserBasketProductItem userBasketProductItem);

        Task<UserBasket> GetUserBasket(int UserId);

        Task<UserBasketProductItem> GetUserBasketProductItem(int BasketId, string Slug);

        Task<UserBasketProductItem> GetUserBasketProductItem(string Slug);

        Task<UserBasketProductItem> UpadteUserBasketProductItem(string Slug, decimal Price, decimal LatestPrice, bool UserChangedSeen);
    }
}
