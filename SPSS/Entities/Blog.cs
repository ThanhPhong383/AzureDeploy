using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("BlogCategory")]
        public int BlogCategoryId { get; set; }

        [Required]
        [MaxLength(155)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public int Status { get; set; }

        public string? Image { get; set; }  

        // Navigation properties
        public virtual AppUser? AppUser { get; set; }
        public virtual BlogCategory? BlogCategory { get; set; }
    }
}
