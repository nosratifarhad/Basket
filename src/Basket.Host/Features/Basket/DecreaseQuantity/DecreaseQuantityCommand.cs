using MediatR;

namespace Basket.Host.Features.Basket.RemoteBasketItem
{
    public record DecreaseQuantityCommand(int UserBasketItemId, int UserId)
        : IRequest<Unit>
    {
    }
}
