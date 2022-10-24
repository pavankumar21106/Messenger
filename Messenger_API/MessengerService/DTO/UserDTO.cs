using MessengerInfrastructure.Entity;

namespace MessengerService.DTO
{
    public class UserDTO : BaseDTO
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
