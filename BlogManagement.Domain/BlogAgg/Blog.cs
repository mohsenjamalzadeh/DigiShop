using _01_framework.Domain;

namespace BlogManagement.Domain.Blog
{
    public class Blog : EntityBase
    {
        // Category Missed
       
        // Dash Dashi Missed / baghal(づ￣ 3￣)づ

     
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Body { get; private set; }
        public DateTime PublishDate { get; private set; }

        public string Pictrue { get; private set; }
        public string PictrueAlt { get; private set; }
        public string PictrueTitle { get; private set; }

        public string Keywords { get; private set; }
        public string CanonicalAddress { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }

        public int CategoryId { get; private set; }

        public int NumberOfViews { get; private set; }
        public int NumberOfUpVotes { get; private set; }

        public bool IsActive { get; set; }
        public int StudyTime { get; set; }


        protected Blog()
        {

        }
        public Blog(string title, string shortDescription, string body, DateTime publishDate
               , string pictrue, string pictrueAlt, string pictrueTitle, string keywords, string canonicalAddress
               , string metaDescription, string slug, int categoryId, int numberOfViews, int numberOfUpVotes,int studyTime)
        {

            Title = title;
            ShortDescription = shortDescription;
            Body = body;
            PublishDate = publishDate;
            Pictrue = pictrue;
            PictrueAlt = pictrueAlt;
            PictrueTitle = pictrueTitle;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
            NumberOfViews = 0;
            NumberOfUpVotes =0;
            IsActive = false; 
            StudyTime = studyTime;
        }
        public void Edit(string title, string shortDescription, string body, DateTime publishDate
               , string pictrue, string pictrueAlt, string pictrueTitle, string keywords, string canonicalAddress
               , string metaDescription, string slug, int categoryId, int studyTime)
        {
            Title = title;
            ShortDescription = shortDescription;
            Body = body;
            PublishDate = publishDate;
            Pictrue = pictrue;
            PictrueAlt = pictrueAlt;
            PictrueTitle = pictrueTitle;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
            StudyTime = studyTime;
            Modefied();
        }

        public void Active()=>
                IsActive = true;


        public void DeActive()=>
            IsActive = false;

        public int IncreaseVote()=> NumberOfUpVotes++;
        public int DecreaseVote() => NumberOfUpVotes--;
        public int IncreaseNumberOfViews() => NumberOfViews++;

    }


}

