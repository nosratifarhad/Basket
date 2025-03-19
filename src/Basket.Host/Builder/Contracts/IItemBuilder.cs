using Basket.Host.Domain.Basket.Entities;
using Basket.Host.Dto;

namespace Basket.Host.Builder.Contracts
{
    public interface IItemBuilder
    {
        UserBasket WithOutExistingUserBasket(CreateUserBasketDto userBasketDto);
        UserBasket WithExistingUserBasket(UserBasket userBasket, CreateUserBasketDto userBasketDto);
        void ConvertToUserBasketItem(UserBasketItem userBasketItem, CreateUserBasketDto userBasketDto);
    }
}
