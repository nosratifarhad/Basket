using Basket.Host.Dto;

namespace Basket.Host.Services.Contracts
{
    public interface IBasketService
    {
        Task<bool> CreateBasket(UserBasketDto userBasketDto);
    }
}
