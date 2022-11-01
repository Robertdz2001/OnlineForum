using Microsoft.EntityFrameworkCore;

namespace Forum.Entities
{
    public class ForumDbContext : DbContext 
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options): base(options){}


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
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

            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(p => p.Content)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(p => p.CreatedOn)
                .IsRequired();

            modelBuilder.Entity<Answer>()
                .Property(a => a.Content)
                .IsRequired();

            modelBuilder.Entity<Answer>()
                .Property(a => a.CreatedOn)
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .Property(c => c.Content)
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .Property(c => c.CreatedOn)
                .IsRequired();
        }
    }
}
