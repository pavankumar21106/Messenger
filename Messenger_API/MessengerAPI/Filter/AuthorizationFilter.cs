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
            Console.WriteLine("-------------------------------");
            Console.WriteLine(context);
            StringValues UserIdHeader;
            if(context.ActionDescriptor.AttributeRouteInfo.Template.Contains("sign-in")) return;

            context.HttpContext.Request.Headers.TryGetValue("auth", out  UserIdHeader);
            var res = _loginService.AuthorizeUser(UserIdHeader.FirstOrDefault()?? "XymxwLveGP5jZzJG0kDYAdV3W210OBnp");
            if (!res.IsSuccess)
            {
                context.Result = new UnauthorizedResult();
                //context.Result = new JsonResult("Permission denined!");
                return;
            }
        }
    }
}
