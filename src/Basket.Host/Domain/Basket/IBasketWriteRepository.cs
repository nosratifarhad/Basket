using Basket.Host.Domain.Basket.DomainModels;

namespace Basket.Host.Domain.Basket
{
    public interface IBasketWriteRepository
    {
        Task<int> AddBasket(UserBasket basket);

        Task UpdateBasket(UserBasket basket);

        Task UpdateBasketItem(UserBasketItem userBasketItem);

        Task UpdateBasketItems(List<UserBasketItem> userBasketItem);

        Task AddUserBasketItem(UserBasketItem userBasketItem);
    }
}
