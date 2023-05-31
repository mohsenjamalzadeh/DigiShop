using _01_framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; private set; }

        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Picture { get; set; }


        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string KeyWords { get; set; }

        public long ProductCategoryId { get; set; }
        public ProductCategory productCategory { get; set; }
        public List<ProductPicture> ProductPictures { get; set; }

        protected Product(){}

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
            IsDeleted= false;
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
            if(!string.IsNullOrWhiteSpace(picture)) Picture = picture;
            Slug = slug;
            MetaDescription = metaDescription;
            KeyWords = keyWrords;
            ProductCategoryId = productCategoryId;
            base.SetModefiedDate();
        }


        public void Active()=>IsDeleted=false;
        public void DeActive()=>IsDeleted=true;
    }
}
