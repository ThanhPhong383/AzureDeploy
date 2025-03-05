using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AppUser")]
        public required string UserId { get; set; }
        public virtual AppUser? AppUser { get; set; }

        // Khóa ngoại liên kết với Address
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual Address? Address { get; set; }
    }
}
