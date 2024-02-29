using task_volgograd.ansoft.ru.domain.Domain.Message;
using task_volgograd.ansoft.ru.Models;

namespace task_volgograd.ansoft.ru.services
{
    public class AttachmentToModel
    {
        public AttachmentModel ConvertAttachmentToModel(Attachment? attachment, MessageModel? message)
        {
            ArgumentNullException.ThrowIfNull(attachment);
            ArgumentNullException.ThrowIfNull(message);
            return new AttachmentModel
            {
                Id = attachment.Id,
                AttachmentFile = Convert.ToBase64String(attachment.AttachmentFile),
                Message = message
            };
        }

        public Attachment ConvertModelToAttachment(AttachmentModel? attachment, Message? message)
        {
            ArgumentNullException.ThrowIfNull(attachment);
            ArgumentNullException.ThrowIfNull(message);
            return new Attachment
            {
                AttachmentFile = Convert.FromBase64String(attachment.AttachmentFile),
                Message = message
            };
        }
    }
}