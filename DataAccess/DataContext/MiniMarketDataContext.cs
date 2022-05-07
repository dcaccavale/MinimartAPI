using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MinimarketDataContext : DbContext
    {
        public MinimarketDataContext() { }

        public MinimarketDataContext(DbContextOptions<MinimarketDataContext> options)
            : base(options)
        {
        }

        public DbSet<ItemProduct> AddProductCart { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RangeDate> RangeDate { get; set; }
        public DbSet<StockProduct> StockProducts { get; set; }
        public DbSet<Store> Stores   { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           

            //optionsBuilder.UseInMemoryDatabase("Test_DB");
        }
    }

}