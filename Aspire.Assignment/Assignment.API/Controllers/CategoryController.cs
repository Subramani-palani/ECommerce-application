using System;
using System.Threading.Tasks;
using Assignment.Core.Features.Categories.CreateCategoryCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(CreateCategoryCommand createCategoryCommand){

            Guid newCategoryId = await _mediator.Send(createCategoryCommand);

            if(newCategoryId == Guid.Empty){
                BadRequest("Category creation failed");
            }

            return Ok(newCategoryId);
        }
    }
}