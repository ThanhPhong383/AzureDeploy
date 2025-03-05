using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPSS.Entities;
using System.Reflection.Emit;

namespace SPSS.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Capicity> Capicities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SkinType> SkinTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerSheet> AnswerSheets { get; set; }
        public DbSet<AnswerDetail> AnswerDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ProductCapicity> ProductCapicities { get; set; }
        public DbSet<Routines> Routines { get; set; }
        public DbSet<RoutinesProductList> RoutinesProductLists { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductSkinType> ProductSkinTypes { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageStatus> MessageStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Blog>()
                .HasOne(b => b.AppUser)
                .WithMany() 
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Xóa blog khi user bị xóa

            builder.Entity<Blog>()
                .HasOne(b => b.BlogCategory)
                .WithMany()
                .HasForeignKey(b => b.BlogCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany()
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Cascade); // Xóa Address nếu City bị xóa

            builder.Entity<Address>()
                .HasOne(a => a.AddressType)
                .WithMany()
                .HasForeignKey(a => a.AddressTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Không cho phép xóa AddressType nếu Address còn tồn tại

            builder.Entity<Promotion>()
                .HasIndex(p => p.Code)
                .IsUnique(); // Code không được trùng lặp

            builder.Entity<Promotion>()
                .Property(p => p.Status)
                .HasConversion<int>();  // Lưu Enum dưới dạng số nguyên

            builder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AnswerDetail>()
                .HasOne(ad => ad.AnswerSheet)
                .WithMany(answerSheet => answerSheet.AnswerDetails) // Đổi tên biến
                .HasForeignKey(ad => ad.AnswerSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AnswerDetail>()
                .HasOne(ad => ad.Answer)
                .WithMany()
                .HasForeignKey(ad => ad.AnswerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Result>()
                .HasOne(r => r.SkinType)
                .WithOne(st => st.Result)
                .HasForeignKey<Result>(r => r.SkinTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasOne(o => o.Cart)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Cart>()
                .HasOne(c => c.AppUser)
                .WithOne(u => u.Cart) 
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.Entity<Order>()
                .HasOne(o => o.AppUser)
                .WithMany(u => u.Orders) 
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.Entity<Cart>()
                .HasIndex(c => c.UserId)
                .IsUnique();

            builder.Entity<ProductCapicity>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCapicities)
                .HasForeignKey(pc => pc.ProductId);

            builder.Entity<ProductCapicity>()
                .HasOne(pc => pc.Capicity)
                .WithMany(c => c.ProductCapicities)
                .HasForeignKey(pc => pc.CapicityId);

            builder.Entity<RoutinesProductList>()
                .HasOne(rp => rp.Routine)
                .WithMany(r => r.RoutineProducts)
                .HasForeignKey(rp => rp.RoutinesId);

            builder.Entity<RoutinesProductList>()
                .HasOne(rp => rp.Product)
                .WithMany(p => p.RoutineProducts)
                .HasForeignKey(rp => rp.ProductId);

            builder.Entity<Payment>()
                .Property(p => p.PaymentStatus)
                .HasConversion<int>();

            builder.Entity<Order>()
                .HasOne(o => o.Payment)   
                .WithOne(p => p.Order)   
                .HasForeignKey<Payment>(p => p.OrderId) 
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductSkinType>()
               .HasOne(pst => pst.Product)
               .WithMany(p => p.ProductSkinTypes)
               .HasForeignKey(pst => pst.ProductId);

            builder.Entity<ProductSkinType>()
                .HasOne(pst => pst.SkinType)
                .WithMany(st => st.ProductSkinTypes)
                .HasForeignKey(pst => pst.SkinTypeId);

            builder.Entity<UserAddress>()
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.UserAddresses)
                .HasForeignKey(ua => ua.UserId);

            builder.Entity<UserAddress>()
                .HasOne(ua => ua.Address)
                .WithMany(a => a.UserAddresses)
                .HasForeignKey(ua => ua.AddressId);

            builder.Entity<Conversation>()
                .HasOne(c => c.User1)
                .WithMany(u => u.Conversations1)
                .HasForeignKey(c => c.UserId1)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Conversation>()
                .HasOne(c => c.User2)
                .WithMany(u => u.Conversations2)
                .HasForeignKey(c => c.UserId2)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình bảng Message
            builder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình bảng MessageStatus
            builder.Entity<MessageStatus>()
                .HasOne(ms => ms.Message)
                .WithMany(m => m.MessageStatuses)
                .HasForeignKey(ms => ms.MessageId);

            builder.Entity<MessageStatus>()
                .HasOne(ms => ms.User)
                .WithMany(u => u.MessageStatuses)
                .HasForeignKey(ms => ms.UserId);

            builder.Entity<Cart>()
        .Property(c => c.TotalAmount)
        .HasPrecision(18, 2);

            builder.Entity<CartItem>()
                .Property(ci => ci.TotalPrice)
                .HasPrecision(18, 2);

            builder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            builder.Entity<OrderItem>()
                .Property(oi => oi.TotalPrice)
                .HasPrecision(18, 2);

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            builder.Entity<Promotion>()
                .Property(p => p.DiscountValue)
                .HasPrecision(18, 2);

            builder.Entity<Routines>()
                .Property(r => r.Price)
                .HasPrecision(18, 2);
        }
    }
}
