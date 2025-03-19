using MassTransit;
using Basket.Host.Domain.Basket;

namespace Basket.Host.Subscription.PriceChanged
{
    public class PriceChangedConsumer : IConsumer<PriceChangedEvent>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IBasketReadRepository _basketReadRepository;

        public PriceChangedConsumer(
            IBasketWriteRepository basketRepository,
            IBasketReadRepository basketReadRepository)
        {
            _basketWriteRepository = basketRepository;
            _basketReadRepository = basketReadRepository;
        }

        public async Task Consume(ConsumeContext<PriceChangedEvent> context)
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

            await _basketWriteRepository.UpdateBasketItems(userBasketItems);
        }
    }

}
