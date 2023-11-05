using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MessagingDbContext : DbContext
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
                optionsBuilder.UseSqlServer("Server=LAPTOP-AT94SBBO\\SQLEXPRESS;Database=Library11J;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<ImageMessage> ImageMessages { get; set; }
        public DbSet<TextMessage> TextMessages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}