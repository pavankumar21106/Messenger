using MessengerInfrastructure.Entity;
using Microsoft.AspNetCore.Html;

namespace MessengerAPI.Models
{
    //remember: use record for model creation 
    public record MessageModel
    (

        //public string From { get; set; } = null!;
        //public string FromName { get; set; } = null!;
        string To,
        string ToName,
        string Subject,
        string Body,
        List<string> Attachment
    );

    public class MessageResponseModel : BaseModel
    {
        public string From { get; set; } = null!;
        public string FromName { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public List<string> Attachment { get; set; } = null!;
    }
}
