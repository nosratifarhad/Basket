using MediatR;

namespace Basket.Host.Features.Basket.RemoteBasket
{
    public record RemoteBasketCommand(int UserId)
        : IRequest<Unit>
    {
    }
}
