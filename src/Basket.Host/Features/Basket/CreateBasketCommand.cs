using MediatR;

namespace Basket.Host.Features.Basket
{
    public record CreateBasketCommand(string Slug, string ProductItemName, decimal Price,int UserId) : IRequest<bool>
    {
    }
}
