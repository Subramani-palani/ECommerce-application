using System;
using System.Collections;
using System.Threading.Tasks;
using Assignment.Core.Features.Carts.AddToCartCommand;
using Assignment.Core.Features.Carts.DeleteFromCartCommand;
using Assignment.Core.Features.Carts.GetCartItemsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCartAsync(AddToCartCommand addToCartCommand)
        {
            string response = await _mediator.Send(addToCartCommand);
            if(response == "User Not Found" || response == "Cart not found!!")
            {
                return NotFound(response);
            }
            
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFromCart(DeleteFromCartCommand deleteFromCartCommand)
        {
            string response = await _mediator.Send(deleteFromCartCommand);
            if(response == "User Not Found" || response == "Cart not found!!"){
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItems([FromQuery] GetCartItemsQuery getCartItemsQuery)
        {
            return Ok(
                await _mediator.Send(getCartItemsQuery)
            );
        }

    }
}