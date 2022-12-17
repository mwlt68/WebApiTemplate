using Business.Abstract;
using Core.Utilities.Responses;
using DataAccess.Dtos.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllAsync()
        {
            var products = await productService.GetAllAsync();
            var response = new DataResponseModel<List<ProductResponseDto>>(products);
            return Ok(response);
        }

        [HttpGet()]
        public async Task<ActionResult> GetAllAsync([FromQuery] int id)
        {
            var product = await productService.GetByIdAsync(id);
            if (product != null)
            {
                var response = new DataResponseModel<ProductResponseDto>(product);
                return Ok(response);
            }
            else 
                throw new KeyNotFoundException("Product not found !");
        }

        [HttpPost("insert")]
        public async Task<ActionResult> InsertAsync(ProductInsertDto productInsertDto)
        {
            var product = await productService.Insert(productInsertDto);
            var response = new DataResponseModel<ProductResponseDto>(product);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var product = await productService.Update(productUpdateDto);
            var response = new DataResponseModel<ProductResponseDto>(product);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteAsync([FromBody] int id)
        {
            var deleteResult = await productService.DeleteAsync(id);
            var response = new DataResponseModel<bool>(deleteResult);
            return Ok(response);
        }
    }
}
