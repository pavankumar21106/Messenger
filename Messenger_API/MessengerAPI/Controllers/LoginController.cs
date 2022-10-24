using AutoMapper;
using FluentResults;
using MessengerAPI.Models;
using MessengerService.DTO;
using MessengerService.IService;
using Microsoft.AspNetCore.Mvc;

namespace MailServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoginService _loginService;
        public LoginController(IMapper mapper, ILoginService loginService)
        {
            _mapper = mapper;
            _loginService = loginService;
        }

        [HttpPost("sign-in")]
        public async Task<Result<string>> Login(UserModel user)
        {
            return await _loginService.LogIn(_mapper.Map<UserDTO>(user));
        }
    }
}
