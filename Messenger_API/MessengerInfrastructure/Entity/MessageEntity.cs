namespace MessengerInfrastructure.Entity
{
    public class MessageEntity:BaseEntity
    {
        public string From { get; set; } = "Pavan";
        public string FromName { get; set; } = "pavankumar21106@gmail.com";
        public string To { get; set; } = null!;
        public string ToName { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public List<string>? Attachment { get; set; }


    }
}
