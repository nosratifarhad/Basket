using MediatR;

namespace Basket.Host.Features.Basket.Commands.RemoteBasket
{
    public record RemoteBasketCommand(int UserId)
        : IRequest<Unit>
    {
    }
}
