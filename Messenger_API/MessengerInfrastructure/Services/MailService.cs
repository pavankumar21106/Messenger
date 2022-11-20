using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using MessengerInfrastructure.Entity;
using MessengerInfrastructure.IService;
using FluentResults;
using Messenger.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using MessengerService.DTO;

namespace MessengerInfrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly MessageDbContext _messageContext;
        private readonly SmtpConfig _smtpConfig;
        public MailService(MessageDbContext messageDbContext, IServiceProvider services)
        {
            _messageContext = messageDbContext;
            _smtpConfig = services.GetService<IOptions<SmtpConfig>>().Value;
        }
        public async Task<Result<MessageEntity>> SendMailAsync(MessageEntity message)
        {

            var emailMessage = new MimeMessage();
            message.From = _smtpConfig.From;
            message.FromName = _smtpConfig.FromName;
            emailMessage.From.Add(new MailboxAddress(message.FromName, message.From));
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
            client.Connect(_smtpConfig.ServerName, _smtpConfig.PortNumber, SecureSocketOptions.SslOnConnect);
            client.Authenticate(_smtpConfig.UserName, _smtpConfig.Password);
            await client.SendAsync(emailMessage);
            client.Disconnect(true);

            _messageContext.Add(message);

            await _messageContext.SaveChangesAsync();

            return message.ToResult();
        }

        public async Task<List<MessageEntity>> GetMessagesAsync(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                return await _messageContext.Set<MessageEntity>().Where(e => e.From.Contains(searchText) || e.Subject.Contains(searchText) || e.Body.Contains(searchText)).OrderByDescending(e => e.Id).ToListAsync();
            }
            return (await _messageContext.Set<MessageEntity>().OrderByDescending(e => e.Id).ToListAsync());
        }

        public async Task<bool> DeleteMessagesAsync(int id)
        {
            var result = await _messageContext.Set<MessageEntity>().Where(e => e.Id == id).FirstOrDefaultAsync();
            result.IsDeleted = true;
            _messageContext.Update(result);
            await _messageContext.SaveChangesAsync();
            var res = result;
            return true;
        }
    }
}