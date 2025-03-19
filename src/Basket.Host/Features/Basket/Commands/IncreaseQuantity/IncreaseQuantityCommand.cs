using MediatR;

namespace Basket.Host.Features.Basket.Commands.IncreaseQuantity
{
    public record IncreaseQuantityCommand(int UserBasketItemId, int UserId)
        : IRequest<Unit>
    {
    }
}
