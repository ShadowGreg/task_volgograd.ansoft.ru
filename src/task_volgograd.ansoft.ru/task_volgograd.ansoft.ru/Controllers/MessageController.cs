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
            message.Id ??= GetGuid();
            var tempMessage = _messageService.GetMessageAsync((Guid)message.Id).Result;
            if (tempMessage != null && message.SendResult?.ToUpper() == "NOT SENT")
            {
                UpdateMessage((Guid)message.Id, message);
                return Ok("Message updated successfully");
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
        public IActionResult UpdateMessage(Guid messageId, [FromBody] MessageModel newMessage)
        {
            var convertor = new MessageToModel();
            newMessage.Id = messageId;
            var message = convertor.ConvertModelToMessage(newMessage).Result;
            _messageService.UpdateMessageAsync(messageId, message);
            return Ok("Message updated successfully");
        }

        [HttpPost("msg/sendMultiple")]
        public IActionResult SendMultipleMessages([FromBody] MessageModel message, int count, int delayInSeconds)
        {
            List<Message> sentMessages = new List<Message>();
            var convertor = new MessageToModel();

            for (int i = 0; i < count; i++)
            {
                var newMessage = convertor.ConvertModelToMessage(message).Result;
                _messageService.SendMessageAsync(newMessage).Wait();
                sentMessages.Add(newMessage);
                Thread.Sleep(delayInSeconds * 1000);
            }

            // Save the sent messages to the database
            foreach (var sentMessage in sentMessages)
            {
                _messageService.UpdateMessageAsync(sentMessage.Id, sentMessage)
                    .Wait();
            }

            return Ok("Messages sent successfully");
        }

        [HttpGet("info")]
        public IActionResult GetServiceInfo()
        {
            string serviceDescription =
                "Необходимо создать базу данных FireBird и микросервис. В базе создается 2 обязательных таблицы с обязательными полями:\n" +
                "1. Сообщения для отправки: guid сообщения, e-mail, номер телефона, тип отправки сообщения, тема, содержание, результат отправки\n" +
                "2. Приложения: файл для отправки на e-mail\n" +
                "При необходимости другие поля этих таблиц и другие таблицы определяются программистом самостоятельно.\n" +
                "Функционал микросервиса:\n" +
                "1. Получение сообщения для отправки с фиксацией в создаваемой БД и отправкой в ответе GUID сообщения. Guid – необязательный входной параметр. В случае отсутствия параметра в запросе на отправку сообщения – необходимо сгенерировать GUID.\n" +
                "2. При попытке повторной отправки сообщения с зарегистрированным в БД GUID необходимо обновить сообщение. Обновление возможно только в случае, если сообщение еще не было отправлено. В противном случае сервис должен вернуть ошибку.\n" +
                "3. Отправка сообщений заданное количество раз (реализовать настройку данного параметра микросервиса) с фиксацией результатов отправки в БД. Период ожидания между отправками сообщения настраивается (реализовать настройку данного параметра микросервиса)\n" +
                "Микросервис должен иметь следующие ендпоинты:\n" +
                "http://xxx.xxx.xxx/msg - отправка сообщения (post)\n" +
                "http://xxx.xxx.xxx/msg/{guid} - получение результатов отправки сообщения (get)\n" +
                "http://xxx.xxx.xxx/info - информация о сервисе\n" +
                "Микросервис должен иметь API для выполнения всех поставленных задач.";
          

            return StatusCode(200, "Error getting service info: \n" + serviceDescription);
        }
    }
}