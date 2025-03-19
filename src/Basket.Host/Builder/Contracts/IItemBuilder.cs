using Basket.Host.Domain.Basket.Entities;
using Basket.Host.Dto;

namespace Basket.Host.Builder.Contracts
{
    public interface IItemBuilder
    {
        UserBasket WithOutExistingUserBasket(UserBasketDto userBasketDto);
        UserBasket WithExistingUserBasket(UserBasket userBasket, UserBasketDto userBasketDto);
        void ConvertToUserBasketItem(UserBasketItem userBasketItem, UserBasketDto userBasketDto);
    }
}
