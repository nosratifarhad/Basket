using Basket.Host.Builder.Contracts;
using Basket.Host.Domain.Basket;
using Basket.Host.Domain.Basket.DomainModels;
using Basket.Host.Dto;
using Basket.Host.Services.Contracts;

namespace Basket.Host.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IBasketReadRepository _basketReadRepository;
        private readonly IItemBuilder _itemBuilder;

        public BasketService(
            IBasketWriteRepository basketWriteRepository,
            IBasketReadRepository basketReadRepository,
            IItemBuilder itemBuilder)
        {
            _basketWriteRepository = basketWriteRepository;
            _basketReadRepository = basketReadRepository;
            _itemBuilder = itemBuilder;
        }

        public async Task<bool> CreateBasket(UserBasketDto userBasketDto)
        {
            //open tansaction

            var userBasket = await CreateUserBasket(userBasketDto);

            await CreateUserBasketItem(userBasket, userBasketDto);

            //close tansaction

            return true;
        }

        public async Task DecreaseQuantity(DecreaseQuantityDto remoteBasketItemDto)
        {
            var userBasketItem =
                await _basketReadRepository.GetUserBasketItem(remoteBasketItemDto.BasketItemId);
            if (userBasketItem == null)
                throw new Exception("User Basket Item Not Found.");

            userBasketItem.Quantity--;

            if (userBasketItem.Quantity == 0)
            {
                userBasketItem.IsDelete = true;
                userBasketItem.DeleteAt = DateTime.Now;
            }

            await _basketWriteRepository.UpdateBasketItem(userBasketItem);
        }

        public async Task IncreaseQuantity(IncreaseQuantityDto increaseQuantityDto)
        {
            var userBasketItem =
                    await _basketReadRepository.GetUserBasketItem(increaseQuantityDto.BasketItemId);
            if (userBasketItem == null)
                throw new Exception("User Basket Item Not Found.");

            userBasketItem.Quantity++;

            await _basketWriteRepository.UpdateBasketItem(userBasketItem);
        }

        public async Task RemoteBasket(RemoteBasketDto remoteBasketDto)
        {
            var userBasket = await _basketReadRepository.GetUserBasket(remoteBasketDto.UserId);
            if (userBasket == null)
                throw new Exception("User Basket Not Found.");

            userBasket.IsDelete = true;
            userBasket.DeleteAt = DateTime.Now;

            await _basketWriteRepository.UpdateBasket(userBasket);
        }

        #region Private Methods

        private async Task<UserBasket> CreateUserBasket(UserBasketDto userBasketDto)
        {
            var userBasket = await _basketReadRepository.GetUserBasket(userBasketDto.UserId);

            if (userBasket is null)
            {
                userBasket = _itemBuilder.WithOutExistingUserBasket(userBasketDto);

                userBasket.UserId = userBasketDto.UserId;

                userBasket.Id = await _basketWriteRepository.AddBasket(userBasket);
            }
            else
            {
                userBasket = _itemBuilder.WithExistingUserBasket(userBasket, userBasketDto);

                await _basketWriteRepository.UpdateBasket(userBasket);
            }

            return userBasket;
        }

        private async Task CreateUserBasketItem(UserBasket userBasket, UserBasketDto userBasketDto)
        {
            var item = await _basketReadRepository.GetUserBasketItem(userBasket.Id, userBasketDto.Slug);

            _itemBuilder.ConvertToUserBasketItem(item, userBasketDto);

            await _basketWriteRepository.AddUserBasketItem(item);
        }

        #endregion Private Methods
    }
}
