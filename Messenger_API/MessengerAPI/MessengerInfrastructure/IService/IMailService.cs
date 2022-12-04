using FluentResults;
using MessengerInfrastructure.Entity;

namespace MessengerInfrastructure.IService
{
    public interface IMailService
    {
        Task<bool> DeleteMessagesAsync(int id);
        Task<List<MessageEntity>> GetMessagesAsync(string searchText);
        Task<Result<MessageEntity>> SendMailAsync(MessageEntity message);
    }
}