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

                entity.Property(e => e.Attachments).HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            });


        }

    }
}
