using _01_framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }

        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Picture { get; private set; }


        public string Slug { get; private set; }
        public string MetaDescription { get; private set; }
        public string KeyWords { get; private set; }

        public long ProductCategoryId { get; private set; }
        public ProductCategory productCategory { get; private set; }

        public Product(string name, string code, string description,
            string pictureAlt, string pictureTitle, string picture,
            string slug, string metaDescription, string keyWrords,
            long productCategoryId)
        {
            Name = name;
            Code = code;
            Description = description;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Picture = picture;
            Slug = slug;
            MetaDescription = metaDescription;
            KeyWords = keyWrords;
            ProductCategoryId = productCategoryId;
        }


        public void Edit(string name, string code, string description,
            string pictureAlt, string pictureTitle, string picture,
            string slug, string metaDescription, string keyWrords,
            long productCategoryId)
        {
            Name = name;
            Code = code;
            Description = description;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Picture = picture;
            Slug = slug;
            MetaDescription = metaDescription;
            KeyWords = keyWrords;
            ProductCategoryId = productCategoryId;
            base.SetModefiedDate();
        }

    }
}
