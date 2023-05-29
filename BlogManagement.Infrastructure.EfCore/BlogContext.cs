using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext>options):base(options) 
        {

        }

        public DbSet<BlogContext> Blogs { get; set; }
    }
}
