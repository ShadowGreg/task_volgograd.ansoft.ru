using task_volgograd.ansoft.ru.domain.Domain;
using task_volgograd.ansoft.ru.domain.Domain.Message;

namespace task_volgograd.ansoft.ru.domain.Abstractions.Repositories
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task SendMessageAsync(T message);
        Task<Message?> GetMessageAsync(Guid messageId);

        Task UpdateMessageAsync(Guid messageId, T message);

        Task SendMessageMultipleTimesAsync(T message, int numberOfTimes, int delaySeconds);
    }
}