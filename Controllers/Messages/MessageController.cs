using APITestes.Service.Messages;
using Microsoft.AspNetCore.Mvc;


namespace APITestes.Controllers.Messages
{
    [ApiController]
    [Route("message")]
    public class MessageController : ControllerBase
    {
        private readonly IRabbitMQService _rabbitMQService;

        public MessageController(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] MessageDto messageDto)
        {
            try
            {
                _rabbitMQService.PublishMessage(messageDto.Message, messageDto.Contagem);
                return Ok("Message sent to queue.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, detail = ex.InnerException?.Message });
            }
        }
    }
}


