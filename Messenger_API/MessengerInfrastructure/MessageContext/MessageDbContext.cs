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

        public virtual DbSet<MessageEntity> MessageEntity { get; set; } = null!;
        public virtual DbSet<UserEntity> UserEntity { get; set; } = null!;

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

                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.UpdatedDate).HasDefaultValue(DateTime.UtcNow);
                entity.HasQueryFilter(e => e.IsDeleted == false);


                entity.Property(e => e.Attachments).HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            });
            
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("user");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.UserName).HasMaxLength(256);
                entity.Property(e => e.Password).HasMaxLength(256);
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.UpdatedDate).HasDefaultValue(DateTime.UtcNow);
                entity.HasQueryFilter(e => e.IsDeleted == false);

                entity.HasIndex(e => new { e.Email }, "UQ_user_Email")
                    .IsUnique().HasFilter("\"IsDeleted\" != true");
                
                entity.HasIndex(e => new { e.UserName }, "UQ_user_UserName")
                    .IsUnique().HasFilter("\"IsDeleted\" != true");


            });


        }

    }
}
