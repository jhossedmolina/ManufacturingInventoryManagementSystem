using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Application.Responses;
using ManufacturingInventory.Domain.Entities;

namespace ManufacturingInventory.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginDto loginDto)
        {
            return await _userRepository.LoginUserAsync(loginDto);
        }

        public async Task<RegistrationResponse> RegisterUserAsync(ApplicationUser applicationUser)
        {
            return await _userRepository.RegisterUserAsync(applicationUser);
        }
    }
}
