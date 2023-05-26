using System.Reflection.PortableExecutable;

namespace ShopManagement.Application.Contracts.Peoduct
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Picture { get; set; }


        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string KeyWords { get; set; }

        public long ProductCategoryId { get; set; }
    }
}
