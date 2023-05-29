using _01_framework.Domain;
using BlogManagement.Application.Contracts.Blog;

namespace BlogManagement.Domain.BlogAgg
{
    public interface IBlogRepository : IRepository<long, Blog>
    {
        EditBlogDto Edit(long id);

        Task<List<BlogViewModelDto>?> SearchAsync(BlogSearchModelDto blogSearch);
    }
}
