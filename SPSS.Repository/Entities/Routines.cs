using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Routines
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Duration { get; set; } // Duration in minutes or hours?

        [Required]
        public int Frequency { get; set; } // How often the routine should be followed

        [Required]
        public int Status { get; set; }

        // Foreign key to SkinType
        [ForeignKey("SkinType")]
        public int SkinTypeId { get; set; }
        public virtual SkinType? SkinType { get; set; }
        public virtual ICollection<RoutinesProductList> RoutineProducts { get; set; } = new List<RoutinesProductList>();
    }
}
