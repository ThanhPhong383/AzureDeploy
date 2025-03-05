using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class AnswerDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AnswerSheet")]
        public int AnswerSheetId { get; set; }
        public virtual AnswerSheet? AnswerSheet { get; set; }

        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public virtual Answer? Answer { get; set; }
    }
}
