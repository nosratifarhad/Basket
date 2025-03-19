using MediatR;

namespace Basket.Host.Features.Basket.Commands.DecreaseQuantity
{
    public record DecreaseQuantityCommand(int UserBasketItemId, int UserId)
        : IRequest<Unit>
    {
    }
}
