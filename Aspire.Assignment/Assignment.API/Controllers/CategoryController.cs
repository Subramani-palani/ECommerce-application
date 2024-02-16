using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Assignment.Contracts.DTO;
using Assignment.Core.Features.Categories.CreateCategoryCommand;
using Assignment.Core.Features.Categories.DeleteCategoryCommand;
using Assignment.Core.Features.Categories.GetAllCategoryQuery;
using Assignment.Core.Features.Categories.GetProductsByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var getAllCategoryQuery = new GetAllCategoryQuery();
            IEnumerable<CategoriesDTO> allCategories = await _mediator.Send(getAllCategoryQuery);

            return Ok(allCategories);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(CreateCategoryCommand createCategoryCommand){

            Guid newCategoryId = await _mediator.Send(createCategoryCommand);

            if(newCategoryId == Guid.Empty){
                BadRequest("Category creation failed");
            }

            return Ok(newCategoryId);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCategoryAsync([FromQuery]DeleteCategoryCommand deleteCategoryCommand){

            await _mediator.Send(deleteCategoryCommand);

            return Ok("Category Deleted Successfully");
        }

        [HttpGet]
        public async Task<IEnumerable<GetProductsDTO>> GetProductsByCategoryAsync([FromQuery]GetProductsByIdQuery getProductsByIdQuery)
        {
            //Note: HttpGet dosent have any request body so we have to fetch categoryId either as a queryString / Route data.
            List<GetProductsDTO> products = await _mediator.Send(getProductsByIdQuery);

            // Return the products with status code 200 (OK)
            HttpContext.Response.StatusCode = 200;

            return products;
            
        }
    }
}