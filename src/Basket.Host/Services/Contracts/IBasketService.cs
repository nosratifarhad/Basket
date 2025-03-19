using Basket.Host.Dto;

namespace Basket.Host.Services.Contracts
{
    public interface IBasketService
    {
        Task<UserBasketDto> GetBasket(int UserId);

        Task<bool> CreateBasket(CreateUserBasketDto userBasketDto);

        Task DecreaseQuantity(DecreaseQuantityDto remoteBasketItemDto);

        Task IncreaseQuantity(IncreaseQuantityDto increaseQuantityDto);

        Task RemoteBasket(RemoteBasketDto remoteBasketDto);

    }
}
