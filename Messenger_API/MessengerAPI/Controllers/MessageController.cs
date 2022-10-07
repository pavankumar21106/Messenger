using AutoMapper;
using FluentResults;
using MessengerAPI.Models;
using MessengerService.DTO;
using MessengerService.IService;
using Microsoft.AspNetCore.Mvc;

namespace MailServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        [HttpPost("SendMessage")]
        public async Task<ActionResult<MessageDTO>> SendMessageAsync(MessageModel message)
        {
            var messageObj = _mapper.Map<MessageDTO>(message);

            //var result = _mapper.Map<Result<MessageResponseModel>>(_messageService.SendMessage(messageObj));
            var result = await _messageService.SendMessageAsync(messageObj);

            if (result.IsFailed)
            {
                return BadRequest("Error");
            }

            return result.ValueOrDefault;
        }
        [HttpGet("GetMessages")]
        public async Task<ActionResult<List<MessageDTO>>> GetMessagesAsync()
        {
            return await _messageService.GetMessagesAsync();
        }

        [HttpDelete("DeleteMessage")]
        public async Task<ActionResult> DeleteMessageAsync(int id)
        {
            var result = await _messageService.DeleteMessageAsync(id);

            if (!result)
            {
                return BadRequest("Error");
            }
            return Ok();
        }
    }
}
