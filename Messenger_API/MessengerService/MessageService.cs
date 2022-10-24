using AutoMapper;
using FluentResults;
using MessengerInfrastructure.Entity;
using MessengerInfrastructure.IService;
using MessengerService.DTO;
using MessengerService.IService;

namespace MessengerService
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        public MessageService(IMapper mapper, IMailService mailService)
        {
            _mapper = mapper;
            _mailService = mailService;
        }
        public async Task<Result<MessageDTO>> SendMessageAsync(MessageDTO message)
        {
            var messageObj = _mapper.Map<MessageEntity>(message);
            return _mapper.Map<Result<MessageDTO>>(await _mailService.SendMailAsync(messageObj));
        }

        public async Task<List<MessageDTO>> GetMessagesAsync()
        {
            return _mapper.Map<List<MessageDTO>>(await _mailService.GetMessagesAsync());
        }
        
        public async Task<bool> DeleteMessageAsync(int id)
        {
            return await _mailService.DeleteMessagesAsync(id);
        }
    }
}