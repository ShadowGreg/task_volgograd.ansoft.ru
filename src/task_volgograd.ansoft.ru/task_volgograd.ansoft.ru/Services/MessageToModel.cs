using task_volgograd.ansoft.ru.domain.Domain.Message;
using task_volgograd.ansoft.ru.Models;

namespace task_volgograd.ansoft.ru.Services
{
    public class MessageToModel
    {
        public Task<MessageModel> ConvertMessageToModel(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);
            List<AttachmentModel> attachments = new();
            if (message.Attachments == null)
            {
                ArgumentNullException.ThrowIfNull(message.Attachments);
            }

            var messageModel = new MessageModel
            {
                Id = message.Id,
                PhoneNumber = message.PhoneNumber,
                MessageType = message.MessageType,
                Subject = message.Subject,
                Content = message.Content,
                SendResult = message.SendResult,
                Attachments = attachments

            };
            attachments.AddRange(
                message
                    .Attachments
                    .Select
                    (
                        attacment =>
                            new AttachmentToModel()
                                .ConvertAttachmentToModel(attacment, messageModel)
                    ));

            return Task.FromResult(messageModel);
        }

        public Task<Message> ConvertModelToMessage(MessageModel messageModel)
        {
            ArgumentNullException.ThrowIfNull(messageModel);
            if (messageModel.Attachments == null )
            {
                ArgumentNullException.ThrowIfNull(messageModel.Attachments);
            } else if (messageModel.Id == null)
            {
                messageModel.Id = Guid.NewGuid();
            }

            List<Attachment> attachments = new();
            var message = new Message
            {
                Id = messageModel.Id!.Value,
                PhoneNumber = messageModel.PhoneNumber,
                MessageType = messageModel.MessageType,
                Subject = messageModel.Subject,
                Content = messageModel.Content,
                SendResult = messageModel.SendResult,
                Attachments = attachments

            };
            attachments.AddRange(
                messageModel
                    .Attachments
                    .Select
                    (
                        attachment =>
                            new AttachmentToModel()
                                .ConvertModelToAttachment(attachment, message)
                    ));

            return Task.FromResult(message);
        }
    }
}