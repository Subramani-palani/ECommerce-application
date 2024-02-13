using System;
using System.Threading.Tasks;
using Assignment.Contracts.DTO;
using Assignment.Core.Features.User.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> RegisterUser(RegisterUserDTO registerUserDTO){
            var command = new CreateUserCommand(registerUserDTO);
            Guid newId = await _mediator.Send(command);

            if(newId == Guid.Empty){
                return BadRequest();
            }

            return Ok(newId);
        }


        [HttpPost("")]
        public async Task<IActionResult> AuthenticateUser(LoginUserDTO loginUserDTO){
            var command = new SignInUserQuery(loginUserDTO);
            Guid userId = await _mediator.Send(command);

            if(userId == Guid.Empty){
                return BadRequest("Invalid username or password");
            }
            return Ok(new {
                UserId = userId,
                Message = "Login Successfull"
            });
        }


    }
}