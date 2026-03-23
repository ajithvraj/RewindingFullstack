using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Services.Interfaces;

namespace ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductManagementController : ControllerBase
    {

        private readonly IProductService _service;

        public ProductManagementController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProductAsync(int page = 1, int pageSize = 10)
        {

            var result = await _service.GetAllProductsAsync(page, pageSize);
            return Ok(result);


        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            var result = await _service.GetProductbyIdAsync(id);

            if (!result.Success)
            {
                return NotFound();

            }

            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto dto)
        {

            var result = await _service.CreateProductAsync(dto);


            if (!result.Success)
            {
                return BadRequest(result);

            }


            return Ok(result);



        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto dto)
        {
            var updated = await _service.UpdateProductAsync(id, dto);
            if (!updated.Success)
            {
                return BadRequest(updated);
            }

            return Ok(updated);


        }

        [HttpDelete("{id}")] 

        public async Task<IActionResult> DeleteProduct(int id)
        {

            var deleted = await _service.DeleteProductAsync(id);

            if (!deleted.Success) 
            { 
                return BadRequest(deleted);
            
            }

            return Ok(deleted);



        }



    }
}
