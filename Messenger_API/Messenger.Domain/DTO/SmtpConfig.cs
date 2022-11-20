namespace MessengerService.DTO
{
    public class SmtpConfig
    {
        public string ServerName { get; set; } = null!;
        public int PortNumber { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string From { get; set; } = null!;
        public string FromName { get; set; } = null!;
    }
}
