using Basket.Host.Builder.Contracts;
using Basket.Host.Domain.Basket.DomainModels;
using Basket.Host.Dto;

namespace Basket.Host.Builder
{
    public class UserBasketBuilder : IItemBuilder
    {
        private const decimal VAT_PERCENTAGE = 0.09m;

        public UserBasket WithOutExistingUserBasket(UserBasketDto userBasketDto)
        {
            var userBasket = new UserBasket();

            userBasket.Amount = userBasketDto.Price;
            userBasket.DeliveryPrice = 1000;

            decimal totalWithoutVat = userBasket.Amount + userBasket.DeliveryPrice;
            userBasket.VatAmount = totalWithoutVat * VAT_PERCENTAGE;
            userBasket.TotalAmount = totalWithoutVat + userBasket.VatAmount;

            return userBasket;
        }

        public UserBasket WithExistingUserBasket(UserBasket userBasket, UserBasketDto userBasketDto)
        {
            decimal amount = userBasket.Amount + userBasketDto.Price;
            userBasket.Amount = amount;

            userBasket.DeliveryPrice = 1000;

            decimal totalWithoutVat = userBasket.Amount + userBasket.DeliveryPrice;
            userBasket.VatAmount = totalWithoutVat * VAT_PERCENTAGE;

            userBasket.TotalAmount = totalWithoutVat + userBasket.VatAmount;

            return userBasket;
        }

        public void ConvertToUserBasketItem(UserBasketItem userBasketItem, UserBasketDto userBasketDto)
        {
            if (userBasketItem is null)
            {
                userBasketItem = new UserBasketItem
                {
                    Slug = userBasketDto.Slug,
                    Price = userBasketDto.Price,
                    Quantity = 1,
                    ProductName = userBasketDto.ProductName
                };
            }
            else
            {
                userBasketItem.Quantity++;
            }
        }
    }
}
