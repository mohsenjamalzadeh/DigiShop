using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class DefineDiscount
    {
        [Required]
        public List<long> ProductsId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

       
        public bool UsePercentDiscount { get; set; }

        [Required]
        [Range(0,100)]
        public int DiscountRate { get; set; } = 0;

        [Required]
        public double DiscountPrice { get; set; } = 0;

        [Required]
        public string Description { get; set; }


    }
}
