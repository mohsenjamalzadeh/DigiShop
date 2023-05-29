using _01_framework.Application;
using BlogManagement.Application.Contracts.Blog;
using BlogManagement.Domain.BlogAgg;

namespace BlogManagement.Application
{
    public class BlogApplication : IBlogAppliocation
    {
        public readonly IBlogRepository _blogRepository;
        public BlogApplication(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public bool Active(long id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Create(CreateBlogDto blog)
        {
            throw new NotImplementedException();
        }

        public bool DeActive(long id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditBlogDto blog)
        {
            throw new NotImplementedException();
        }

        public Task<List<BlogViewModelDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}