namespace BlogManagement.Application.Contracts.Blog
{
    public class BlogSearchModelDto
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
    }
}
