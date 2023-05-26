namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Picture { get; set; }

        public long NameCategory { get; set; }
        public long CategoryId { get; set; }

        public string ModefiedDate { get; set; }
        public string CreationDate { get; set; }
    }
}
