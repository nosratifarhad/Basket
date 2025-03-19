using Basket.Host.Features.Basket.Commands.CreateBasket;
using Basket.Host.Features.Basket.Commands.DecreaseQuantity;
using Basket.Host.Features.Basket.Commands.IncreaseQuantity;
using Basket.Host.Features.Basket.Commands.RemoteBasket;
using Basket.Host.Features.Basket.Queries.GetBasket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("api/v1/baskets")]
        public async Task<IActionResult> GetBasket()
        {
            int userId = 123;//Get From Token

            var query = new GetBasketQuery(userId);

            var basket = await _mediator.Send(query);

            return Ok(basket);
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
