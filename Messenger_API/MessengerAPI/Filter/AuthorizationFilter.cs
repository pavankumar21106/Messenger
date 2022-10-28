using AutoMapper;
using MessengerService.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MessengerAPI.Filter
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly IMapper _mapper;
        private readonly ILoginService _loginService;
        public AuthorizationFilter(IMapper mapper, ILoginService loginService)
        {
            _mapper = mapper;
            _loginService = loginService;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine(context);
            var res = _loginService.AuthorizeUser("y7E2dPB6AGYqzxkXG8ZWaevwVKNR01Or");
            if (!res.IsSuccess)
            {
                context.Result = new UnauthorizedResult();
                //context.Result = new JsonResult("Permission denined!");
                return;
            }
        }
    }
}
