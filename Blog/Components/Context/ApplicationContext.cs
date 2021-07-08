using Blog.Components.Comment;
using Blog.Components.Post;
using Blog.Components.User;
using Microsoft.EntityFrameworkCore;

namespace Blog.Components.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DbSet<PostModel> Posts { get; set; }

        public DbSet<CommentModel> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=BlogDatabase;Username=postgres;Password=password;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PostModel>()
                .HasOne<UserModel>()
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.CreatorId);
        }
    }
}