using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Domain.Entities;

namespace ManufacturingInventory.Application.Interfaces
{
    public interface IProductHttpService
    {
        Task<ApiResponseDto<IEnumerable<ProductDtoResponse>>> GetAllProducts(string token);

        Task<ApiResponseDto<ProductDtoResponse>> AddProducts(string token, ProductDto productDto);

        Task<bool> DeleteProduct(string token, int id);
    }
}
