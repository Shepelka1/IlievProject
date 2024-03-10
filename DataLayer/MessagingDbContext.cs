using BusinessLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MessagingDbContext : IdentityDbContext<User>
    {
        public MessagingDbContext()
        {
        
        }
        public MessagingDbContext(DbContextOptions options) : base(options)
        {
               
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //set connection string here and maybe in json
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS; Database=MessagingDb;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendRequest>().HasOne(q => q.Sender).WithMany(q => q.FriendRequests).HasForeignKey(e => e.SenderId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageMessage> ImageMessages { get; set; }
        public DbSet<TextMessage> TextMessages { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
    }
}