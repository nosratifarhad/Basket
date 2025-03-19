using Basket.Host.Dto;
using Basket.Host.Services.Contracts;
using MediatR;

namespace Basket.Host.Features.Basket.Commands.DecreaseQuantity
{
    public class DecreaseQuantityCommandHandler : IRequestHandler<DecreaseQuantityCommand, Unit>
    {
        private readonly IBasketService _basketService;

        public DecreaseQuantityCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<Unit> Handle(DecreaseQuantityCommand request, CancellationToken cancellationToken)
        {
            var remoteBasketItemDto = new DecreaseQuantityDto()
            {
                UserBasketItemId = request.UserBasketItemId,
                UserId = request.UserId,
            };

            await _basketService.DecreaseQuantity(remoteBasketItemDto);

            return Unit.Value;
        }
    }
}
