using Entities;
using Entities.Discount;
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
        public DbSet<DailyTimeRange> DailyTimeRange { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemProduct> ItemProduct { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RangeDate> RangeDate { get; set; }
        public DbSet<StockProduct> StockProducts { get; set; }
        public DbSet<Store> Stores { get; set; }



        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherProduct> VouchersProduct { get; set; }
        public DbSet<VoucherCategory> VouchersCategory { get; set; }

        public DbSet<CategoriesDiscountToApply> CategoriesDiscountToApply { get; set; }
        public DbSet<ProductDiscountToApply> ProductDiscountToApply { get; set; }
        public DbSet<ExceptedDiscountProduct> ExceptedDiscountProduct { get; set; }

        public DbSet<PayTakeDiscount> PayTakeDiscount { get; set; }
        public DbSet<PercentageDiscount> PercentageDiscounts { get; set; }
        public DbSet<PercentageSecundDiscount> PercentageSecundDiscounts { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           

            //optionsBuilder.UseInMemoryDatabase("Test_DB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voucher>()
             .ToTable("Vouchers")
            .HasDiscriminator<string>("Type")
            .HasValue<VoucherCategory>("VoucherCategory")
            .HasValue<VoucherProduct>("VoucherProduct")
                .IsComplete(false);

            modelBuilder.Entity<GenericDiscount>()
                .ToTable("Discounts")
                .HasDiscriminator<string>("Type")
                .HasValue<PercentageDiscount>("PercentageDiscount")
                .HasValue<PercentageSecundDiscount>("PercentageSecundDiscount")
                .HasValue<PayTakeDiscount>("PayTakeDiscount")
                .IsComplete(false);


            


        }
    }

}