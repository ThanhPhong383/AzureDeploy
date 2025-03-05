using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class ProductCapicity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CapicityId { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        // Thiết lập quan hệ với bảng Product
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        // Thiết lập quan hệ với bảng Capacity
        [ForeignKey("CapicityId")]
        public Capicity? Capicity { get; set; }
    }
}
