using Microsoft.AspNetCore.Mvc;
using task_volgograd.ansoft.ru.domain.Abstractions.Repositories;
using task_volgograd.ansoft.ru.domain.Domain.Message;
using task_volgograd.ansoft.ru.Models;
using task_volgograd.ansoft.ru.Services;

namespace task_volgograd.ansoft.ru.Controllers
{
    [ApiController]
    [Route("api")]
    public class MessageController : ControllerBase
    {
        private readonly IRepository<Message> _messageService;

        public MessageController(IRepository<Message> messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("msg")]
        public IActionResult SendMessageAsync([FromBody] MessageModel message)
        {
                if (message.Id == null)
                {
                    message.Id = GetGuid();
                }

                var convertor = new MessageToModel();
                var newMessage = convertor.ConvertModelToMessage(message).Result;

                _messageService.SendMessageAsync(newMessage);
                return Ok("Message GUID: " + newMessage.Id);

                Guid GetGuid()
                {
                    return Guid.NewGuid();
                }
        }

        [HttpPut("msg/{messageId}")]
        public IActionResult UpdateMessage(Guid messageId, [FromBody] string newMessage)
        {
            // try
            // {
            //     _messageService.UpdateMessageAsync(messageId, newMessage);
            //     return Ok("Message updated successfully");
            // }
            // catch (Exception ex)
            // {
            //     return StatusCode(500, "Error updating message: " + ex.Message);
            // }
            return StatusCode(500, "Error updating message: ");
        }

        [HttpPost("msg/sendMultiple")]
        public IActionResult SendMultipleMessages([FromBody] string message, int count, int delayInSeconds)
        {
            // try
            // {
            //     _messageService.SendMultipleMessages(message, count, delayInSeconds);
            //     return Ok("Messages sent successfully");
            // }
            // catch (Exception ex)
            // {
            //     return StatusCode(500, "Error sending messages: " + ex.Message);
            // }
            return StatusCode(500, "Error sending messages: ");
        }

        [HttpGet("info")]
        public IActionResult GetServiceInfo()
        {
            // try
            // {
            //     var info = _messageService.GetServiceInfo();
            //     return Ok(info);
            //     
            // }
            // catch (Exception ex)
            // {
            //     return StatusCode(500, "Error getting service info: " + ex.Message);
            // }
            return StatusCode(500, "Error getting service info: ");
        }
    }
}