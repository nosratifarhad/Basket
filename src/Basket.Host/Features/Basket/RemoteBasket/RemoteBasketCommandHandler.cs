using Basket.Host.Dto;
using Basket.Host.Services.Contracts;
using MediatR;

namespace Basket.Host.Features.Basket.RemoteBasket
{
    public class RemoteBasketCommandHandler : IRequestHandler<RemoteBasketCommand, Unit>
    {
        private readonly IBasketService _basketService;

        public RemoteBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<Unit> Handle(RemoteBasketCommand request, CancellationToken cancellationToken)
        {
            var remoteBasketDto = new RemoteBasketDto()
            {
                UserId = request.UserId,
            };

            await _basketService.RemoteBasket(remoteBasketDto);

            return Unit.Value;
        }
    }
}
