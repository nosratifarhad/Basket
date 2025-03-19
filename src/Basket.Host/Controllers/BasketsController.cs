using Basket.Host.Features.Basket.CreateBasket;
using Basket.Host.Features.Basket.IncreaseQuantity;
using Basket.Host.Features.Basket.RemoteBasket;
using Basket.Host.Features.Basket.RemoteBasketItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BasketsController(IMediator mediator) => _mediator = mediator;

        [HttpPost(Name = "baskets")]
        public async Task<IActionResult> AddItemToBasket([FromBody] CreateBasketCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }

        [HttpDelete(Name = "baskets")]
        public async Task<IActionResult> RemoteBasket()
        {
            int userId = 123;//Get From Token

            var command = new RemoteBasketCommand(userId);

            await _mediator.Send(command);

            return Created();
        }

        [HttpPut(Name = "baskets/{basketItemId}/decrease")]
        public async Task<IActionResult> DecreaseQuantity(int basketItemId)
        {
            int userId = 123;//Get From Token

            var command = new DecreaseQuantityCommand(basketItemId, userId);

            await _mediator.Send(command);

            return Created();
        }

        [HttpPut(Name = "baskets/{basketItemId}/increase")]
        public async Task<IActionResult> IncreaseQuantity(int basketItemId)
        {
            int userId = 123;//Get From Token

            var command = new IncreaseQuantityCommand(basketItemId, userId);

            await _mediator.Send(command);

            return Created();
        }

    }
}
