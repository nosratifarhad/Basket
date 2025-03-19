using Basket.Host.Builder.Contracts;
using Basket.Host.Domain.Basket;
using Basket.Host.Domain.Basket.Entities;
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

        public async Task<UserBasketDto> GetBasket(int UserId)
        {
            var userBasket = await _basketReadRepository.GetUserBasket(UserId);
            if (userBasket == null)
                throw new Exception("User Basket Not Found.");

            var userBasketDto = CreateUserBasketDto(userBasket);

            return userBasketDto;
        }

        public async Task<bool> CreateBasket(CreateUserBasketDto userBasketDto)
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
                await _basketReadRepository.GetUserBasketItem(remoteBasketItemDto.UserBasketItemId);
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
                    await _basketReadRepository.GetUserBasketItem(increaseQuantityDto.UserBasketItemId);
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

        private async Task<UserBasket> CreateUserBasket(CreateUserBasketDto userBasketDto)
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

        private async Task CreateUserBasketItem(UserBasket userBasket, CreateUserBasketDto userBasketDto)
        {
            var item = await _basketReadRepository.GetUserBasketItem(userBasket.Id, userBasketDto.Slug);

            _itemBuilder.ConvertToUserBasketItem(item, userBasketDto);

            await _basketWriteRepository.AddUserBasketItem(item);
        }

        private UserBasketDto CreateUserBasketDto(UserBasket userBasket)
        {
            var UserBasketItemDtos = new List<UserBasketItemDto>();

            foreach (var item in userBasket.UserBasketItems)
            {
                UserBasketItemDtos.Add(new UserBasketItemDto()
                {
                    Discount = item.Discount,
                    LatestPrice = item.LatestPrice,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Slug = item.Slug,
                    UserBasketId = item.UserBasketId,
                    UserChangedSeen = item.UserChangedSeen
                });
            }

            var userBasketDto = new UserBasketDto()
            {
                UserId = userBasket.UserId,
                Amount = userBasket.Amount,
                DeliveryPrice = userBasket.DeliveryPrice,
                TotalAmount = userBasket.TotalAmount,
                VatAmount = userBasket.VatAmount,
                UserBasketItems = UserBasketItemDtos,
            };

            return userBasketDto;
        }

        #endregion Private Methods
    }
}
