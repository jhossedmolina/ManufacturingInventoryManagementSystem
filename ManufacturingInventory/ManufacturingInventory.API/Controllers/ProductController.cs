using AutoMapper;
using ManufacturingInventory.API.Responses;
using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Application.Services;
using ManufacturingInventory.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManufacturingInventory.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            var productsDtoResponse = _mapper.Map<IEnumerable<ProductDtoResponse>>(products);
            var response = new ApiResponse<IEnumerable<ProductDtoResponse>>(productsDtoResponse);
            return Ok(response);
        }

        [HttpGet("GetProductsByStatus/{status}")]
        public async Task<ActionResult> GetProductsByStatus(string status)
        {
            var products = _productService.GetProductsByStatus(status);
            if (products.Count == 0)
                return NotFound();

            var productsDtoResponse = _mapper.Map<List<ProductDtoResponse>>(products);
            var response = new ApiResponse<List<ProductDtoResponse>>(productsDtoResponse);
            return Ok(response);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult> GetProductsById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product is null)
                return NotFound();

            var productDtoResponse = _mapper.Map<ProductDtoResponse>(product);
            var response = new ApiResponse<ProductDtoResponse>(productDtoResponse);
            return Ok(response);
        }


        [HttpPost("AddProduct")]
        public async Task<ActionResult> InsertProducts(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productService.AddProducts(product);

            var productDtoResponse = _mapper.Map<ProductDtoResponse>(product);
            var response = new ApiResponse<ProductDtoResponse>(productDtoResponse);
            return CreatedAtAction(nameof(GetProductsById), new { id = productDtoResponse.Id }, response);
        }

        [HttpPut("MarkProductAsDefective")]
        public async Task<IActionResult> MarkProductAsDefective(int id)
        {
            await _productService.MarkProductAsDefective(id);
            return NoContent();
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = id;
            await _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            return NoContent();
        }

    }
}
