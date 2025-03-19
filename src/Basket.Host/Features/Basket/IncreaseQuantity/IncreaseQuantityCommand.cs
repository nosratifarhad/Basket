using MediatR;

namespace Basket.Host.Features.Basket.IncreaseQuantity
{
    public record IncreaseQuantityCommand(int UserBasketItemId, int UserId)
        : IRequest<Unit>
    {
    }
}
