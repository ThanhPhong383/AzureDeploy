using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class RoutinesProductList
    {
        [Key]
        public int Id { get; set; }

        // Foreign key to Routines
        [ForeignKey("Routines")]
        public int RoutinesId { get; set; }
        public virtual Routines? Routine { get; set; }

        // Foreign key to Product (assuming you have a Product entity)
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
