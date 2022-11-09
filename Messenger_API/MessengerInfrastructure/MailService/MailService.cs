using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using MessengerInfrastructure.Entity;
using MessengerInfrastructure.IService;
using FluentResults;
using MessengerInfrastructure.MessageContext;
using Microsoft.EntityFrameworkCore;

namespace MessengerInfrastructure.MailService
{
    public class MailService : IMailService
    {
        private readonly MessageDbContext _messageContext;
        public MailService(MessageDbContext messageDbContext)
        {
            _messageContext = messageDbContext;
        }
        public async Task<Result<MessageEntity>> SendMailAsync(MessageEntity message)
        {

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(address: new MailboxAddress(message.FromName, message.From));
            emailMessage.To.Add(new MailboxAddress(message.ToName, message.To));
            emailMessage.Subject = message.Subject;
            var bodyBuilder = new BodyBuilder();
            if (message.Attachment.Count > 0)
            {
                foreach (var attachment in message.Attachment)
                {
                    //bodyBuilder.LinkedResources.Add(@"D:\Trainings\MailService\MailServiceAPI\images\mail-header-solid.png");
                    bodyBuilder.Attachments.Add(@$"{attachment}");
                }
            }

            bodyBuilder.HtmlBody = @$"{message.Body}";
            emailMessage.Body = bodyBuilder.ToMessageBody();
            message.CreatedDate = DateTime.UtcNow;
            message.UpdatedDate = DateTime.UtcNow;

            using var client = new SmtpClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
            client.Authenticate("pavankumar21106@gmail.com", "wueddtqvzgjgukce");
            //client.Send(emailMessage);
            client.Disconnect(true);

            _messageContext.Add(message);

            await _messageContext.SaveChangesAsync();

            return message.ToResult();
        }

        public async Task<List<MessageEntity>> GetMessagesAsync()
        {
            return (await _messageContext.Set<MessageEntity>().ToListAsync());
        }

        public async Task<bool> DeleteMessagesAsync(int id)
        {
            var result = await _messageContext.Set<MessageEntity>().Where(e => e.Id == id).FirstOrDefaultAsync();
            result.IsDeleted = true;
            _messageContext.Update(result);
            _messageContext.SaveChangesAsync();
            var res = result;
            return true;
        }
    }
}