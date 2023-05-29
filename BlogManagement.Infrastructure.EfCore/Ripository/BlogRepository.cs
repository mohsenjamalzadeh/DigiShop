using _01_framework.Domain;
using _01_framework.Infrastructure;
using BlogManagement.Application.Contracts.Blog;
using BlogManagement.Domain.BlogAgg;

namespace BlogManagement.Infrastructure.EfCore.Ripository
{
    public class BlogRepository : RepositoryBase<long, Blog>, IBlogRepository
    {
        public readonly BlogContext _context;
        public BlogRepository(BlogContext context):base(context)
        {
            _context = context;
        }

        public EditBlogDto Edit(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BlogViewModelDto>?> SearchAsync(BlogSearchModelDto blogSearch)
        {
            throw new NotImplementedException();
        }
    }
}
