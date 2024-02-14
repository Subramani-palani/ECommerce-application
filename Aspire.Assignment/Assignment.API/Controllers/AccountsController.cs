using System;
using System.Threading.Tasks;
using Assignment.Contracts.DTO;
using Assignment.Core.Features.User.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterUserDTO registerUserDTO){
            var command = new CreateUserCommand(registerUserDTO);
            Guid newId = await _mediator.Send(command);

            if(newId == Guid.Empty){
                return BadRequest();
            }

            return Ok(newId);
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginUserDTO loginUserDTO){
            var signInUserQuery = new SignInUserQuery(loginUserDTO);
            AuthenticationResponse authenticationResponse = await _mediator.Send(signInUserQuery);

            //Todo: Set the jwt token in an HTTP-only cookie

            if(authenticationResponse == null){
                return NotFound("Invalid username or password");
            }
            return Ok(
                authenticationResponse
            );
        }

        [HttpGet]
        public async Task<IActionResult> LogoutAsync(){
            var signOutUserQuery = new SignOutUserQuery();
            await _mediator.Send(signOutUserQuery);

            //Todo: delete the jwt token inside the cookie

            return Ok(new {message="User Logged out successfully"});
            
        }


    }
}