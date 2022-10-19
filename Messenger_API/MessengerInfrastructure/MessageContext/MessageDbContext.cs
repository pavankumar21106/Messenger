using MessengerInfrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace MessengerInfrastructure.MessageContext
{
    public class MessageDbContext : DbContext
    {
        //for Linqpad
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Include Error Detail=true");
        //}
        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
        {

        }

        public virtual DbSet<MessageEntity> MessageEntitie { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageEntity>(entity =>
            {
                entity.ToTable("Message");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.To).HasMaxLength(256);
                entity.Property(e => e.ToName).HasMaxLength(256);
                entity.Property(e => e.From).HasMaxLength(256);
                entity.Property(e => e.FromName).HasMaxLength(256);
                entity.Property(e => e.Title).HasMaxLength(1024);
                entity.HasQueryFilter(e => e.IsDeleted == false);

                entity.Property(e => e.Attachment).HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            });


            var list = new List<MessageEntity>();
            list.Add(new MessageEntity
            {
                Id = 10,
                From = "TestFrom@gmail.com",
                To = "testTo@gmail.com",
                Attachment = new List<string> { "Attachments" },
                Message = "Message",
                CreatedDate = DateTime.UtcNow,
                FromName = "FromName",
                Title = "Title",
                ToName = "ToName",
                UpdatedDate = DateTime.UtcNow,
                IsDeleted = false,
            });

            list.Add(new MessageEntity
            {
                Id = 11,
                From = "11TestFrom@gmail.com",
                To = "11testTo@gmail.com",
                Attachment = new List<string> { "11Attachments" },
                Message = "11Message",
                CreatedDate = DateTime.UtcNow,
                FromName = "11FromName",
                Title = "11Title",
                ToName = "1ToName",
                UpdatedDate = DateTime.UtcNow,
                IsDeleted = false,
            });

            list.Add(new MessageEntity
            {
                Id = 12,
                From = "12TestFrom@gmail.com",
                To = "12testTo@gmail.com",
                Attachment = new List<string> { "12Attachments" },
                Message = "12Message",
                CreatedDate = DateTime.UtcNow,
                FromName = "12FromName",
                Title = "12Title",
                ToName = "12ToName",
                UpdatedDate = DateTime.UtcNow,
                IsDeleted = false,
            });

            foreach (var item in list)
            {
                modelBuilder.Entity<MessageEntity>().HasData(item);
            }

        }
    }
}
