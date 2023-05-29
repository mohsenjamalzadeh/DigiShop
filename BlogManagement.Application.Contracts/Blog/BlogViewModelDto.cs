namespace BlogManagement.Application.Contracts.Blog
{
    public class BlogViewModelDto
    {
        public long Id { get; set; }
        public string Title { get;  set; } = null!;
        public string ShortDescription { get;  set; } = null!;
        public string PublishDate { get;  set; } = null!;
        public string CreationDate { get; set; } = null!;
    }
}
