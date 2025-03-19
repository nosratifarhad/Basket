using Basket.Host.Dto;
using MediatR;

namespace Basket.Host.Features.Basket.Queries.GetBasket
{
    public record GetBasketQuery(int UserId) : IRequest<UserBasketDto>
    {
    }
}
