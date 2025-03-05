using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Sender")]
        public required string SenderId { get; set; }
        public virtual AppUser? Sender { get; set; }

        [ForeignKey("Conversation")]
        public int ConversationId { get; set; }
        public virtual Conversation? Conversation { get; set; }

        public string Content { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Quan hệ với MessageStatus
        public virtual ICollection<MessageStatus> MessageStatuses { get; set; } = new List<MessageStatus>();

    }
}
