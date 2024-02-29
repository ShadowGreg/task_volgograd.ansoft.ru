namespace task_volgograd.ansoft.ru.Models
{
    public class AttachmentModel
    {
        public string? Id { get; set; }
        public string? AttachmentFile { get; set; }
        public MessageModel? Message { get; set; } = null;
    }
}