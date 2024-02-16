using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using Assignment.Core.Features.Products.CreateProductCommand;
using Assignment.Core.Features.Products.DeleteProductCommand;
using Assignment.Core.Features.Products.GetAllProductsQuery;
using Assignment.Core.Features.Products.UpdateProductCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var getAllProductsQuery = new GetAllProductsQuery();
            IEnumerable<GetProductsDTO> products = await _mediator.Send(getAllProductsQuery);

            return Ok(products);

        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody]CreateProductCommand createProductCommand)
        {
            Guid newProductId = await _mediator.Send(createProductCommand);

            if(newProductId == Guid.Empty){
                return BadRequest("Product creation failed");
            }

            return Ok(newProductId);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProductAsync([FromQuery]DeleteProductCommand deleteProductCommand)
        {
            await _mediator.Send(deleteProductCommand);

            return Ok("Product Deleted Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductCommand updateProductCommand)
        {
            GetProductsDTO updatedProduct = await _mediator.Send(updateProductCommand);

            if(updatedProduct == null){
                return BadRequest("Product Updation failed");
            }

            return Ok(updatedProduct);
        }
    }
}