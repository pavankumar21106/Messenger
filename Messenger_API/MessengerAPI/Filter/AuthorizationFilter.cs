using AutoMapper;
using MessengerService.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

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
            StringValues UserIdHeader;
            context.HttpContext.Request.Headers.TryGetValue("auth", out  UserIdHeader);
            if(context.ActionDescriptor.AttributeRouteInfo.Template.Contains("sign-in")) return;

            var res = _loginService.AuthorizeUser(UserIdHeader.FirstOrDefault());
            if (!res.IsSuccess)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
