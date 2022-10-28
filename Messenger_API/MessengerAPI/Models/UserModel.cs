using MessengerInfrastructure.Entity;

namespace MessengerAPI.Models
{
    public class UserModel
    {
        public string Email { get; set; } 
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    public class UserResponseModel
    {

    }
}
