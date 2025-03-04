using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSS.Entities
{
    public class AnswerSheet
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; } = string.Empty;
        public virtual AppUser? AppUser { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int TotalPoint { get; set; }
        public virtual ICollection<AnswerDetail> AnswerDetails { get; set; } = new List<AnswerDetail>();

    }
}
