using Basket.Host.Domain.Basket.Entities;

namespace Basket.Host.Domain.Basket
{
    public interface IBasketWriteRepository
    {
        Task<int> AddBasket(UserBasket basket);

        Task UpdateBasket(UserBasket basket);

        Task UpdateBaskets(List<UserBasket> baskets);

        Task AddUserBasketItem(UserBasketItem userBasketItem);

        Task UpdateBasketItem(UserBasketItem userBasketItem);

        Task UpdateBasketItems(List<UserBasketItem> userBasketItem);
    }
}
