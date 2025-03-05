using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User1")]
        public required string UserId1 { get; set; }
        public virtual AppUser? User1 { get; set; }

        [ForeignKey("User2")]
        public required string UserId2 { get; set; }
        public virtual AppUser? User2 { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Quan hệ với Message
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
