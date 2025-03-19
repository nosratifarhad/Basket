using MassTransit;
using Basket.Host.Domain.Basket;

namespace Basket.Host.Subscription.PriceChanged
{
    public class PriceChangedConsumer : IConsumer<PriceChangedEvent>
    {
        private readonly IBasketRepository _basketRepository;

        public PriceChangedConsumer(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task Consume(ConsumeContext<PriceChangedEvent> context)
        {
            var userBasketProductItem = await _basketRepository.GetUserBasketProductItem(context.Message.Slug);
            if (userBasketProductItem == null)
            {
                Console.WriteLine("log : userBasketProductItem is null !");
                return;
            }

            await _basketRepository.UpadteUserBasketProductItem(
                context.Message.Slug,
                context.Message.Price,
                context.Message.Price,
                false);
        }
    }

}
