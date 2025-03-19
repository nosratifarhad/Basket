using Basket.Host.Domain.Basket.DomainModels;
using Basket.Host.Dto;

namespace Basket.Host.Builder.Contracts
{
    public interface IItemBuilder
    {
        UserBasket WithOutExistingUserBasket(UserBasketDto userBasketDto);
        UserBasket WithExistingUserBasket(UserBasket userBasket, UserBasketDto userBasketDto);
        void ConvertToUserBasketProductItem(UserBasketProductItem userBasketProductItem, UserBasketDto userBasketDto);
    }
}
