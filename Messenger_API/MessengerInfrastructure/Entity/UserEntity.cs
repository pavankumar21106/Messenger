namespace MessengerInfrastructure.Entity
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }=null!;
        public string Password { get; set; }=null!;
    }
}
