using MessengerInfrastructure.Entity;
using FluentResults;
using MessengerInfrastructure.MessageContext;
using MessengerInfrastructure.IService;

namespace MessengerInfrastructure.MailService
{
    public class SSOService : ISSOService
    {
        private readonly MessageDbContext _messageContext;
        public SSOService(MessageDbContext messageDbContext)
        {
            _messageContext = messageDbContext;
        }
        public async Task<Result<string>> LogIn(UserEntity user)
        {
            if (_messageContext.UserEntity.Where(e => e.UserName == user.UserName || e.Email == user.Email).Where(e => e.Password == user.Password).Any())
            {
                return Result.Ok("success");
            }
            return Result.Fail("user does not exist");
        }
    }
}