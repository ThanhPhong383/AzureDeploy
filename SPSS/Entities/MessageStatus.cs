using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class MessageStatus
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Message")]
        public int MessageId { get; set; }
        public virtual Message? Message { get; set; }

        [ForeignKey("User")]
        public required string UserId { get; set; }
        public virtual AppUser? User { get; set; }

        public bool IsRead { get; set; } = false;
        public DateTime? ReadAt { get; set; }
    }
}
