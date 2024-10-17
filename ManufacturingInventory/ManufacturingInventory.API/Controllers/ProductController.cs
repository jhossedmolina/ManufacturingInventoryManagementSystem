using AutoMapper;
using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Application.Interfaces;
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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{status}")]
        public async Task<ActionResult> GetProductsByStatus(string status)
        {
            var products = _productService.GetProductsByStatus(status);
            if (products.Count == 0)
                return NotFound();

            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return Ok(productsDto);
        }

        /*[HttpPost]
        public async Task<ActionResult> InsertProducts(List<ProductDto> productsDtoList)
        {
            foreach(var productDto in productsDtoList)
            {
            }
        }*/
    }
}
