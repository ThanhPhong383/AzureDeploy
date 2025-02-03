using Microsoft.EntityFrameworkCore;
using SPSS.Entities;

namespace SPSS.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
            public DbSet<User> Users { get; set; }
    }

}
