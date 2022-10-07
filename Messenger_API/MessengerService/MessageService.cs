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
        private readonly IMailService _mailServiceper;
        public MessageService(IMapper mapper, IMailService mailService)
        {
            _mapper = mapper;
            _mailServiceper = mailService;
        }
        public async Task<Result<MessageDTO>> SendMessageAsync(MessageDTO message)
        {
            var messageObj = _mapper.Map<MessageEntity>(message);
            return _mapper.Map<Result<MessageDTO>>(await _mailServiceper.SendMailAsync(messageObj));
        }

        public async Task<List<MessageDTO>> GetMessagesAsync()
        {
            return _mapper.Map<List<MessageDTO>>(await _mailServiceper.GetMessagesAsync());
        }
        
        public async Task<bool> DeleteMessageAsync(int id)
        {
            return await _mailServiceper.DeleteMessagesAsync(id);
        }
    }
}