using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Application.Responses;
using ManufacturingInventory.Domain.Entities;
using System.Net.Http.Json;

namespace ManufacturingInventory.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/User/Login", loginDto);
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result!;
        }

        public async Task<RegistrationResponse> RegisterUserAsync(ApplicationUser applicationUser)
        {
            var response = await _httpClient.PostAsJsonAsync("api/User/Register", applicationUser);
            var result = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
            return result!;
        }
    }
}
