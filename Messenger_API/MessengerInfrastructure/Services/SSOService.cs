using MessengerInfrastructure.Entity;
using FluentResults;
using MessengerInfrastructure.MessageContext;
using MessengerInfrastructure.IService;

namespace MessengerInfrastructure.Services
{
    public class SSOService : ISSOService
    {
        private readonly MessageDbContext _messageContext;
        private readonly UserTokenGenarator _userTokenGenarator;
        public SSOService(MessageDbContext messageDbContext, UserTokenGenarator userTokenGenarator)
        {
            _messageContext = messageDbContext;
            _userTokenGenarator = userTokenGenarator;
        }
        public async Task<Result<string>> LogIn(UserEntity user)
        {
            var userEntity = _messageContext.UserEntity.Where(e => e.UserName == user.UserName.ToLower() || e.Email == user.UserName.ToLower()).Where(e => e.Password == user.Password).FirstOrDefault();
            var id = userEntity is null ? 0 : userEntity.Id;
            if (id>0)
            {
                var token = _userTokenGenarator.GetUserToken(id);
                return Result.Ok(token);
            }
            return Result.Fail("user does not exist");
        }
        
        public Result<string> AuthorizeUser(string userToken)
        {
            var userId = _userTokenGenarator.GetUserId(userToken);
            if (_messageContext.UserEntity.Where(e => e.Id == userId).Any())
            {
                return Result.Ok();
            }
            return Result.Fail("user does not exist");
        }
    }
}