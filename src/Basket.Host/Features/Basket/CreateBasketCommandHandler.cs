using MediatR;
using Basket.Host.Dto;
using Basket.Host.Services.Contracts;

namespace Basket.Host.Features.Basket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, bool>
    {
        private readonly IBasketService _basketService;

        public CreateBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<bool> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var userBasketDto = new UserBasketDto(request.Slug, request.ProductItemName, request.Price, request.UserId);

            return await _basketService.CreateBasket(userBasketDto);
        }
    }
}
