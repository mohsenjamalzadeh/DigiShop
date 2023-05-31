using _01_framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }

        public bool IsDeleted { get; private set; }

        public long ProductId { get; private set; }
        public Product Product { get; private set; }

        public ProductPicture(string picture, string pictureAlt, string pictureTitle, long productId)
        {
            this.Picture = picture;
            this.PictureAlt = pictureAlt;
            this.PictureTitle = pictureTitle;
            ProductId = productId;
            IsDeleted = false;
        }


        public void Edit(string picture, string pictureAlt, string pictureTitle, long productId)
        {
            if (!string.IsNullOrWhiteSpace(picture)) Picture = picture;
            this.PictureAlt = pictureAlt;
            this.PictureTitle = pictureTitle;
            ProductId = productId;
            IsDeleted = false;
            base.SetModefiedDate();
        }

        public void Active() => IsDeleted = false;
        public void DeActive() => IsDeleted = true;
    }
}
