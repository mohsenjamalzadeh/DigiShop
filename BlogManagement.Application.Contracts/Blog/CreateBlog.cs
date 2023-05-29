namespace BlogManagement.Application.Contracts.Blog
{
    public class CreateBlogDto
    { 

        public string Title { get;  set; } = null!;
        public string ShortDescription { get;  set; } = null!;
        public string Body { get;  set; } = null!;

        public string PublishDate { get;  set; } = null!;
        public string? Pictrue { get;  set; }
        public string? PictrueAlt { get;  set; }
        public string? PictrueTitle { get;  set; }
                     
        public string Keywords { get;  set; } = null!;
        public string? CanonicalAddress { get;  set; }
        public string? MetaDescription { get;  set; } = null!;
        public string Slug { get;  set; } = null!;

        public int CategoryId { get;  set; } 

        public int NumberOfViews { get;  set; }
        public int NumberOfUpVotes { get;  set; }

        public int StudyTime { get; set; }
    }
}
