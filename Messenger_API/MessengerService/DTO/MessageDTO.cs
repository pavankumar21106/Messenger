using MessengerInfrastructure.Entity;

namespace MessengerService.DTO
{
    public class MessageDTO: BaseDTO
    {
        public string To { get; set; } = null!;
        public string From { get; set; } = null!;
        public string FromName { get; set; } = null!;
        public string ToName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public List<string> Attachment { get; set; }


    }
}
