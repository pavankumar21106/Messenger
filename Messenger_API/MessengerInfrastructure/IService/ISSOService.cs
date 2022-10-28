using FluentResults;
using MessengerInfrastructure.Entity;

namespace MessengerInfrastructure.IService
{
    public interface ISSOService
    {
        Task<Result<string>> LogIn(UserEntity user);
        Result<string> AuthorizeUser(string userToken);
    }
}