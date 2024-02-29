using Microsoft.EntityFrameworkCore;
using task_volgograd.ansoft.ru.domain.Domain.Message;

namespace task_volgograd.ansoft.ru.dataAccess
{
    public class DataContext
        : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public DataContext()
        { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Attachment>()
                .HasKey(a => a.Id);


            modelBuilder.Entity<Message>()
                .HasMany(m => m.Attachments)
                .WithOne(a => a.Message)
                .HasForeignKey(a => a.MessageGuid)
                .IsRequired();
        }
    }
}