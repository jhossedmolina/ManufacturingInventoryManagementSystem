using AutoMapper;
using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Application.Services;
using ManufacturingInventory.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManufacturingInventory.API.Controllers
{
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
            return Ok(productsDtoResponse);
        }

        [HttpGet("GetProductsByStatus/{status}")]
        public async Task<ActionResult> GetProductsByStatus(string status)
        {
            var products = _productService.GetProductsByStatus(status);
            if (products.Count == 0)
                return NotFound();

            var productsDtoResponse = _mapper.Map<List<ProductDtoResponse>>(products);
            return Ok(productsDtoResponse);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult> GetProductsById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product is null)
                return NotFound();

            var productDtoResponse = _mapper.Map<ProductDtoResponse>(product);
            return Ok(productDtoResponse);
        }


        [HttpPost("AddProduct")]
        public async Task<ActionResult> InsertProducts(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productService.AddProducts(product);

            var productDtoResponse = _mapper.Map<ProductDtoResponse>(product);
            return CreatedAtAction(nameof(GetProductsById), new { id = productDtoResponse.Id }, productDtoResponse);
        }

        [HttpPut("MarkProductAsDefective")]
        public async Task<IActionResult> MarkProductAsDefective(int id)
        {
            var currentProduct = await _productService.GetProductById(id);
            if (currentProduct is null) 
                return NotFound();

            await _productService.MarkProductAsDefective(id);
            var productDtoResponse = _mapper.Map<ProductDtoResponse>(currentProduct);

            return Ok(productDtoResponse);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            var currentProduct = await _productService.GetProductById(id);
            if (currentProduct is null)
                return NotFound();

            var product = _mapper.Map<Product>(productDto);
            product.Id = currentProduct.Id;
            await _productService.UpdateProduct(product);
            var productDtoResponse = _mapper.Map<ProductDtoResponse>(product);
            return Ok(productDtoResponse);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var currentProduct = await _productService.GetProductById(id);
            if (currentProduct is null)
                return NotFound();

            var result = await _productService.DeleteProduct(id);
            return NoContent();
        }

    }
}
