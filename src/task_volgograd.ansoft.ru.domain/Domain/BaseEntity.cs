using System.ComponentModel.DataAnnotations;

namespace task_volgograd.ansoft.ru.domain.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}