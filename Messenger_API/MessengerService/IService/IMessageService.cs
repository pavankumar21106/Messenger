using FluentResults;
using MessengerService.DTO;

namespace MessengerService.IService
{
    public interface IMessageService
    {
        Task<bool> DeleteMessageAsync(int id);
        Task<List<MessageDTO>> GetMessagesAsync(string searchText="");
        Task<Result<MessageDTO>> SendMessageAsync(MessageDTO message);
    }
}