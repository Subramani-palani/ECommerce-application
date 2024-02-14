using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment.Contracts.DTO;
using Assignment.Core.Features.User.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync(){
            GetAllUsersQuery getAllUsersQuery = new ();
            return await _mediator.Send(getAllUsersQuery);
        }

        

        
    }
}