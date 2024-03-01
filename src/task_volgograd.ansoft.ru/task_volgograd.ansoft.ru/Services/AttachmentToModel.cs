using task_volgograd.ansoft.ru.domain.Domain.Message;
using task_volgograd.ansoft.ru.Models;

 namespace task_volgograd.ansoft.ru.Services
{
    public class AttachmentToModel
    {
        public AttachmentModel ConvertAttachmentToModel(Attachment? attachment, MessageModel? message)
        {
            ArgumentNullException.ThrowIfNull(attachment);
            ArgumentNullException.ThrowIfNull(message);

            if (attachment.AttachmentFile == null)
            {
                return null!;
            }

            string attachmentFile = Convert.ToBase64String(attachment.AttachmentFile);
            return new AttachmentModel
            {
                AttachmentFile = attachmentFile
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