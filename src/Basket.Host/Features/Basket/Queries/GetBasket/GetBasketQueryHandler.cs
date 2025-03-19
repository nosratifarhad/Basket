using Basket.Host.Dto;
using Basket.Host.Services.Contracts;
using MediatR;

namespace Basket.Host.Features.Basket.Queries.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, UserBasketDto>
    {
        private readonly IBasketService _basketService;

        public GetBasketQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<UserBasketDto> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            return await _basketService.GetBasket(request.UserId);
        }
    }
}
