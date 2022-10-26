using MessengerInfrastructure.Entity;
using Microsoft.AspNetCore.Html;

namespace MessengerAPI.Models
{
    public class MessageModel
    {

        public string To { get; set; } = null!;
        //public string From { get; set; } = null!;
        //public string FromName { get; set; } = null!;
        public string ToName { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public List<string>? Attachment { get; set; }
    }

    public class BaseMessageResponseModel:  BaseModel
    {

    }
    public class MessageResponseModel: BaseMessageResponseModel
    {

    }
}
