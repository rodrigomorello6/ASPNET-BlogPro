using AspNetPro.Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetPro.Blog.Infrastruture.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public BlogContext(DbContextOptions<BlogContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // register all mappings
            var assembly = typeof(BlogContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
