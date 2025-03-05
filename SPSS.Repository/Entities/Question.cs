using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string QuestionDESC { get; set; } = string.Empty;

        [Required]
        public int Status { get; set; }
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    }
}
