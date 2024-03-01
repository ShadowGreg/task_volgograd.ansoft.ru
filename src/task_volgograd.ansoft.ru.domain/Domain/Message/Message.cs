namespace task_volgograd.ansoft.ru.domain.Domain.Message
{
    public class Message : BaseEntity
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MessageType { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string? SendResult { get; set; }

        public ICollection<Attachment>? Attachments { get; set; }
    }
}