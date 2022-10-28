using MessengerInfrastructure.Entity;
using FluentResults;
using MessengerInfrastructure.MessageContext;
using MessengerInfrastructure.IService;
using HashidsNet;

namespace MessengerInfrastructure.MailService
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
            if (_messageContext.UserEntity.Where(e => e.UserName == user.UserName || e.Email == user.UserName).Where(e => e.Password == user.Password).Any())
            {
                var token = _userTokenGenarator.GetUserToken(1);
                var id = _userTokenGenarator.GetUserId(token);
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

    public class UserTokenGenarator
    {
        private readonly TokenGenarator _tokenGenarator;
        public UserTokenGenarator(TokenGenarator tokenGenarator)
        {
            _tokenGenarator = tokenGenarator;
        }

        public string GetUserToken(int id)
        {
            var token = _tokenGenarator.GetTokenGenaratorInstance().Encode(id);
            return token;
        }
        public int GetUserId(string token)
        {
            var id = _tokenGenarator.GetTokenGenaratorInstance().DecodeSingle(token);
            return id;
        }
    }

    public class TokenGenarator
    {
        private readonly Hashids _hashids;
        public TokenGenarator()
        {
            _hashids = new Hashids("salt", 32);
        }

        public Hashids GetTokenGenaratorInstance()
        {
            return _hashids;
        }
    }
}