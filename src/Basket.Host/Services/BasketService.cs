using Basket.Host.Builder.Contracts;
using Basket.Host.Domain.Basket;
using Basket.Host.Domain.Basket.DomainModels;
using Basket.Host.Dto;
using Basket.Host.Services.Contracts;

namespace Basket.Host.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IItemBuilder _itemBuilder;

        public BasketService(IBasketRepository basketRepository, IItemBuilder itemBuilder)
        {
            _basketRepository = basketRepository;
            _itemBuilder = itemBuilder;
        }

        public async Task<bool> CreateBasket(UserBasketDto userBasketDto)
        {
            //open tansaction

            var userBasket = await CreateUserBasket(userBasketDto);

            await CreateUserBasketProductItem(userBasket, userBasketDto);

            //close tansaction

            return true;
        }

        private async Task<UserBasket> CreateUserBasket(UserBasketDto userBasketDto)
        {
            var userBasket = await _basketRepository.GetUserBasket(userBasketDto.UserId);

            if (userBasket is null)
            {
                userBasket = _itemBuilder.WithOutExistingUserBasket(userBasketDto);

                userBasket.UserId = userBasketDto.UserId;

                userBasket.Id = await _basketRepository.AddBasket(userBasket);
            }
            else
            {
                userBasket = _itemBuilder.WithExistingUserBasket(userBasket, userBasketDto);

                await _basketRepository.UpdateBasket(userBasket);
            }

            return userBasket;
        }

        private async Task CreateUserBasketProductItem(UserBasket userBasket, UserBasketDto userBasketDto)
        {
            var item = await _basketRepository.GetUserBasketProductItem(userBasket.Id, userBasketDto.Slug);

            _itemBuilder.ConvertToUserBasketProductItem(item, userBasketDto);

            await _basketRepository.AddUserBasketProductItem(item);
        }

    }
}
