namespace MessengerInfrastructure.Entity
{
    public class MessageEntity:BaseEntity
    {
        public string To { get; set; } = null!;
        public string From { get; set; } = null!;
        public string FromName { get; set; } = null!;
        public string ToName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public List<string> Attachments { get; set; }


    }
}
