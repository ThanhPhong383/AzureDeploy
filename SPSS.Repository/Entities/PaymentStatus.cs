namespace SPSS.Entities
{
    public enum PaymentStatus
    {
        Pending = 0,    // Chờ thanh toán
        Success = 1,    // Thanh toán thành công
        Failed = 2,     // Thanh toán thất bại
        Canceled = 3,   // Đã hủy
    }
}
