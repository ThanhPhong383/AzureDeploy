using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;

namespace SPSS.Entities
{
    public class AppUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public Cart? Cart { get; set; }

        public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

        // Quan hệ với bảng Conversation
        public virtual ICollection<Conversation> Conversations1 { get; set; } = new List<Conversation>();
        public virtual ICollection<Conversation> Conversations2 { get; set; } = new List<Conversation>();

        // Quan hệ với Message
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

        // Quan hệ với MessageStatus
        public virtual ICollection<MessageStatus> MessageStatuses { get; set; } = new List<MessageStatus>();



    }
}
