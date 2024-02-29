namespace task_volgograd.ansoft.ru.Models
{
    public class MessageModel
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MessageType { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string? SendResult { get; set; }
        public ICollection<AttachmentModel>? Attachments { get; set; }
    }
}