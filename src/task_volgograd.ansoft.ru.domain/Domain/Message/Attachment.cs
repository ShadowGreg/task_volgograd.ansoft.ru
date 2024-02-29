namespace task_volgograd.ansoft.ru.domain.Domain.Message
{
    public class Attachment : BaseEntity
    {
        public byte[]? AttachmentFile { get; set; }
        public string? MessageGuid { get; set; }
        public Message? Message { get; set; } = null;
    }
}