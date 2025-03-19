﻿using Basket.Host.Dto;
using Basket.Host.Services.Contracts;
using MediatR;

namespace Basket.Host.Features.Basket.IncreaseQuantity
{
    public class IncreaseQuantityCommandHandler : IRequestHandler<IncreaseQuantityCommand, Unit>
    {
        private readonly IBasketService _basketService;

        public IncreaseQuantityCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<Unit> Handle(IncreaseQuantityCommand request, CancellationToken cancellationToken)
        {
            var increaseQuantityDto = new IncreaseQuantityDto()
            {
                BasketItemId = request.BasketItemId,
                UserId = request.UserId,
            };

            await _basketService.IncreaseQuantity(increaseQuantityDto);

            return Unit.Value;
        }
    }
}
