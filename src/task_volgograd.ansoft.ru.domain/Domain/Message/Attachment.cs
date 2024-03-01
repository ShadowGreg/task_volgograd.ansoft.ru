namespace task_volgograd.ansoft.ru.domain.Domain.Message
{
    public class Attachment : BaseEntity
    {
        public byte[]? AttachmentFile { get; set; }
        public Guid MessageId { get; set; }
        public Message? Message { get; set; } = null;
    }
}