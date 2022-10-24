using AutoMapper;
using FluentResults;
using MessengerInfrastructure.Entity;
using MessengerInfrastructure.IService;
using MessengerService.DTO;
using MessengerService.IService;

namespace MessengerService
{
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;
        private readonly ISSOService _sSSOService;
        public LoginService(IMapper mapper, ISSOService sSoService)
        {
            _mapper = mapper;
            _sSSOService = sSoService;
        }

        public async Task<Result<string>> LogIn(UserDTO user)
        {
            return await _sSSOService.LogIn(_mapper.Map<UserEntity>(user));

        }
    }
}