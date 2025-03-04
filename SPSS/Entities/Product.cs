using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Promotion")]
        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public string? Ingredients { get; set; }
        public string? UsageInstructions { get; set; }
        public string? Benefits { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<ProductCapicity> ProductCapicities { get; set; } = new List<ProductCapicity>();
        public virtual ICollection<RoutinesProductList> RoutineProducts { get; set; } = new List<RoutinesProductList>();
        public virtual ICollection<ProductSkinType> ProductSkinTypes { get; set; } = new List<ProductSkinType>();

    }
}
