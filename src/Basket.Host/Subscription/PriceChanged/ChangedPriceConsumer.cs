using MassTransit;
using Basket.Host.Domain.Basket;
using Basket.Host.Dto;
using Basket.Host.Domain.Basket.Entities;

namespace Basket.Host.Subscription.PriceChanged
{
    public class ChangedPriceConsumer : IConsumer<ChangedPriceEvent>
    {
        private const decimal VAT_PERCENTAGE = 0.09m;
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IBasketReadRepository _basketReadRepository;

        public ChangedPriceConsumer(
            IBasketWriteRepository basketRepository,
            IBasketReadRepository basketReadRepository)
        {
            _basketWriteRepository = basketRepository;
            _basketReadRepository = basketReadRepository;
        }

        public async Task Consume(ConsumeContext<ChangedPriceEvent> context)
        {
            var userBasketItems = await _basketReadRepository.GetUserBasketItems(context.Message.Slug);
            if (!userBasketItems.Any())
            {
                Console.WriteLine("log : userBasketItem is null !");
                return;
            }

            foreach (var item in userBasketItems)
            {
                item.Price = context.Message.Price;
                item.LatestPrice = context.Message.Price;
                item.UserChangedSeen = false;
            }

            var userBasketIds = userBasketItems.Select(a => a.UserBasketId);

            var baskets = await _basketReadRepository.GetUserBaskets(userBasketIds);

            var newUserBaskets = UpdateUserBaskets(context, baskets);

            await _basketWriteRepository.UpdateBaskets(newUserBaskets);
            await _basketWriteRepository.UpdateBasketItems(userBasketItems);
        }

        public List<UserBasket> UpdateUserBaskets(ConsumeContext<ChangedPriceEvent> context, List<UserBasket> userBaskets)
        {
            foreach (var userBasket in userBaskets)
            {
                userBasket.Amount = context.Message.Price;

                decimal totalWithoutVat = userBasket.Amount + userBasket.DeliveryPrice;
                userBasket.VatAmount = totalWithoutVat * VAT_PERCENTAGE;
                userBasket.TotalAmount = totalWithoutVat + userBasket.VatAmount;
            }

            return userBaskets;
        }
    }

}
