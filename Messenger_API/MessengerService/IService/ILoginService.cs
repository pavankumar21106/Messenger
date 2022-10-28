using FluentResults;
using MessengerInfrastructure.Entity;
using MessengerService.DTO;

namespace MessengerService.IService
{
    public interface ILoginService
    {
        Task<Result<string>> LogIn(UserDTO user);

        Result<string> AuthorizeUser(string userToken);
    }
}