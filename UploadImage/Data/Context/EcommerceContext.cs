using Microsoft.EntityFrameworkCore;
using UploadImage.Data.Modals;

namespace UploadImage.Data.Context
{
    public class EcommerceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }
    }
}
