using AutoMapper;
using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Application.Responses;
using ManufacturingInventory.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManufacturingInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> LogUserIn(LoginDto loginDto)
        {
            var result = await _userService.LoginUserAsync(loginDto);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<LoginResponse>> RegisterUser(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDto);
            var result = await _userService.RegisterUserAsync(applicationUser);
            return Ok(result);
        }
    }
}
