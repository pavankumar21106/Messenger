namespace MessengerInfrastructure.Entity
{
    public class MessageEntity:BaseEntity
    {
        public string From { get; set; } 
        public string FromName { get; set; }
        public string To { get; set; } = null!;
        public string ToName { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public List<string>? Attachment { get; set; }


    }
}
