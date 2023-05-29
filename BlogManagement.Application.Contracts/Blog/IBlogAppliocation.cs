using _01_framework.Application;

namespace BlogManagement.Application.Contracts.Blog
{
    public interface IBlogAppliocation
    {
        OperationResult Create(CreateBlogDto blog);
        OperationResult Edit(EditBlogDto blog);

        bool Active(long id);
        bool DeActive(long id);

        Task<List<BlogViewModelDto>> GetAll();
      
    }
}
