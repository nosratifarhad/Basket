using MediatR;

namespace Basket.Host.Features.Basket.IncreaseQuantity
{
    public record IncreaseQuantityCommand(int BasketItemId, int UserId)
        : IRequest<Unit>
    {
    }
}
