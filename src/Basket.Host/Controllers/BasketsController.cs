using Basket.Host.Features.Basket.CreateBasket;
using Basket.Host.Features.Basket.IncreaseQuantity;
using Basket.Host.Features.Basket.RemoteBasket;
using Basket.Host.Features.Basket.RemoteBasketItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Host.Controllers
{
    [ApiController]
    public class BasketsController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BasketsController(IMediator mediator) => _mediator = mediator;

        [HttpPost("api/v1/baskets")]
        public async Task<IActionResult> AddItemToBasket([FromBody] CreateBasketCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }

        [HttpDelete("api/v1/baskets")]
        public async Task<IActionResult> RemoteBasket()
        {
            int userId = 123;//Get From Token

            var command = new RemoteBasketCommand(userId);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("api/v1/baskets/{userBasketItemId}/decrease")]
        public async Task<IActionResult> DecreaseQuantity(int userBasketItemId)
        {
            int userId = 123;//Get From Token

            var command = new DecreaseQuantityCommand(userBasketItemId, userId);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("api/v1/baskets/{userBasketItemId}/increase")]
        public async Task<IActionResult> IncreaseQuantity(int userBasketItemId)
        {
            int userId = 123;//Get From Token

            var command = new IncreaseQuantityCommand(userBasketItemId, userId);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
