using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; } // Quan hệ với Order

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        public string? TransactionId { get; set; } // Mã giao dịch (có thể null)

        public DateTime? PaymentDate { get; set; } // Ngày thanh toán (nếu đã thanh toán)

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Thời điểm tạo
    }
}
