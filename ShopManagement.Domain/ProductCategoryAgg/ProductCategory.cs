using _01_framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get;  set; }
        public string Description { get;  set; }

        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Picture { get;  set; }

        public string KeyWords { get;  set; }
        public string MetaDescription { get;  set; }
        public string Slug { get;  set; }

        public List<Product> Products { get; set; }

        public ProductCategory(string name,
            string description, string pictureAlt,
            string pictureTitle, string picture, string keyWords,
            string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Picture = picture;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
        }


        public void Edit(string name,
            string description, string pictureAlt,
            string pictureTitle, string? picture, string keyWords,
            string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            if (!string.IsNullOrWhiteSpace(picture)) Picture = picture;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            SetModefiedDate();
        }
    }
}
