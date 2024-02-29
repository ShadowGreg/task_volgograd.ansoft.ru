using task_volgograd.ansoft.ru.domain.Abstractions.Repositories;
using task_volgograd.ansoft.ru.domain.Domain;
using task_volgograd.ansoft.ru.domain.Domain.Message;


namespace task_volgograd.ansoft.ru.dataAccess.Repositories
{
    public class EfRepository<T>(DataContext dataContext) 
        : IRepository<T>
        where T : BaseEntity
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task SendMessageAsync(T message)
        {
            await _dataContext.Set<T>().AddAsync(message);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateMessageAsync(T message)
        {
            var entity = await _dataContext.Set<T>().FindAsync(message.Id);
            if (entity != null)
            {
                _dataContext.Entry(entity).CurrentValues.SetValues(message);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task SendMessageMultipleTimesAsync(T message, int numberOfTimes, int delaySeconds)
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                await SendAsync(message);
                await Task.Delay(delaySeconds * 1000);
            }
        }

        private async Task SendAsync(T message)
        {
            if (message is Message messageEntity)
            {
                messageEntity.SendResult = "Not Sent";
                await _dataContext.Set<Message>().AddAsync(messageEntity);
                messageEntity.SendResult = "Sent";
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}