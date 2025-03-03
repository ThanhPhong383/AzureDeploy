using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class ProductSkinType
    {
        [Key]
        public int Id { get; set; }

        // Khóa ngoại liên kết với Product
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        // Khóa ngoại liên kết với SkinType
        [ForeignKey("SkinType")]
        public int SkinTypeId { get; set; }
        public virtual SkinType? SkinType { get; set; }
    }
}
