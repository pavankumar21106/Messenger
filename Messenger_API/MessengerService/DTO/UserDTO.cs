using MessengerInfrastructure.Entity;

namespace MessengerService.DTO
{
    public class UserDTO : BaseDTO
    {
        public string Email { get; set; } 
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
