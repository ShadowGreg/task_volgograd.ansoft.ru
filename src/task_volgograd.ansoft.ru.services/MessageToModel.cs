﻿using task_volgograd.ansoft.ru.domain.Domain.Message;
using task_volgograd.ansoft.ru.Models;

namespace task_volgograd.ansoft.ru.services
{
    public class MessageToModel
    {
        public MessageModel ConvertMessageToModel(Message message)
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

            return messageModel;
        }

        public Message ConvertModelToMessage(MessageModel messageModel)
        {
            ArgumentNullException.ThrowIfNull(messageModel);
            if (messageModel.Attachments == null)
            {
                ArgumentNullException.ThrowIfNull(messageModel.Attachments);
            }

            List<Attachment> attachments = new();
            var message = new Message
            {
                Id = messageModel.Id,
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

            return message;
        }
    }
}