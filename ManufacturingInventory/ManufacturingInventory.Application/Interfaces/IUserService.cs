﻿using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Application.Responses;
using ManufacturingInventory.Domain.Entities;

namespace ManufacturingInventory.Application.Interfaces
{
    public interface IUserService
    {
        Task<RegistrationResponse> RegisterUserAsync(ApplicationUser applicationUser);

        Task<LoginResponse> LoginUserAsync(LoginDto loginDto);
    }
}
