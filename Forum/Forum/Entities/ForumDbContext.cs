using Microsoft.EntityFrameworkCore;

namespace Forum.Entities
{
    public class ForumDbContext : DbContext 
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options): base(options){}


        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(25)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<Role>()
               .Property(r => r.Name)
               .IsRequired();
        }
    }
}
