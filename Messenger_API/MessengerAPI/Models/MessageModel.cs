using MessengerInfrastructure.Entity;
using Microsoft.AspNetCore.Html;

namespace MessengerAPI.Models
{
    public class MessageModel
    {

        public string To { get; set; } = null!;
        public string From { get; set; } = null!;
        public string FromName { get; set; } = null!;
        public string ToName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public List<string> Attachments { get; set; }
    }

    public class BaseMessageResponseModel:  BaseEntity
    {

    }
    public class MessageResponseModel: BaseMessageResponseModel
    {

    }

}
