using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Application.Responses;
using ManufacturingInventory.Domain.Entities;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace ManufacturingInventory.Application.Services
{
    public class ProductHttpService : IProductHttpService
    {
        private readonly HttpClient _httpClient;

        public ProductHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponseDto<IEnumerable<ProductDtoResponse>>> GetAllProducts(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetFromJsonAsync<ApiResponseDto<IEnumerable<ProductDtoResponse>>>("api/Product/GetAllProducts");
            return response;
        }

        public async Task<ApiResponseDto<ProductDtoResponse>> AddProducts(string token, ProductDto productDto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("api/Product/AddProduct", productDto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponseDto<ProductDtoResponse>>();
            return result;
        }

        public async Task<bool> DeleteProduct(string token, int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"api/Product/DeleteProduct/{id}");
            if (!response.IsSuccessStatusCode)
                return false;
            return true;
        }
    }
}
