using System.Threading.Tasks;
using Assignment.Core.Features.Carts.AddToCartCommand;
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
    }
}