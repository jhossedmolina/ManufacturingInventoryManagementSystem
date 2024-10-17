using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Application.Responses;
using ManufacturingInventory.Domain.Entities;
using ManufacturingInventory.Infraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingInventory.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ManufacturingInventoryDbContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(ManufacturingInventoryDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginDto loginDto)
        {
            var getUser = await FindUserByEmail(loginDto.Email);
            if (getUser is null)
                return new LoginResponse(false, "No se ha encontrado el usuario");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, getUser.Password);
            if (checkPassword)
                return new LoginResponse(true, "Se ha iniciado sesión satisfatoriamente", GenerateJWTToken(getUser));
            else
                return new LoginResponse(false, "Por favor verifique el usuario y la contraseña");
        }

        private string GenerateJWTToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<ApplicationUser> FindUserByEmail(string email) =>
            await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<RegistrationResponse> RegisterUserAsync(ApplicationUser applicationUser)
        {
            var getUser = await FindUserByEmail(applicationUser.Email);
            if (getUser is not null)
                return new RegistrationResponse(false, "El usuario ya existe");

            applicationUser.Password = BCrypt.Net.BCrypt.HashPassword(applicationUser.Password);

            _context.ApplicationUsers.Add(applicationUser);
            await _context.SaveChangesAsync();
            return new RegistrationResponse(true, "Usuario creado correctamente");
        }
    }
}
