using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MinPoint { get; set; }

        [Required]
        public int MaxPoint { get; set; }

        [ForeignKey("SkinType")]
        public int SkinTypeId { get; set; }

        // Navigation property
        public virtual SkinType? SkinType { get; set; }
    }
}
