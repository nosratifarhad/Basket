using Basket.Host.Features.Basket;
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


        [HttpPost(Name = "Basket")]
        public async Task<IActionResult> AddItemToBasket([FromBody] CreateBasketCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }
    }
}
