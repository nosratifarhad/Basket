using MediatR;

namespace Basket.Host.Features.Basket.RemoteBasketItem
{
    public record DecreaseQuantityCommand(int BasketItemId, int UserId)
        : IRequest<Unit>
    {
    }
}
