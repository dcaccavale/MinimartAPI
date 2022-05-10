
using Entities;
using Entities.Discount;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new MinimarketDataContext(serviceProvider.GetRequiredService<DbContextOptions<MinimarketDataContext>>()))
            {
                // Agregando  a la BD
              //  DeleteDataBase(_context);
                //Seed(_context);
                if (_context.Stores.Any())
                {
                    return;
                }
                //  Seed(_context);

            }
        }

        private static void DeleteDataBase(MinimarketDataContext _context)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.SaveChanges();
        }

        public static void InitDataBase(MinimarketDataContext _context)
        {
            DeleteDataBase(_context);
            Seed(_context);

        }
        public static void Seed(MinimarketDataContext _context)
        {
            Store cocoD = new Store { Name = "COCO Downtown", Address = "Altovolta 2595" };
            Store cocoB = new Store { Name = "COCO Bay", Address = "Mac Fly 1985" };
            Store cocoM = new Store { Name = "COCO Mall", Address = "Artur Hard 15669" };
            _context.Stores.AddRange(cocoD, cocoB, cocoM);
            _context.SaveChanges();
            var DailyTimeRangeD = GetListDailyTime();
            var DailyTimeRangeB = GetListDailyTime();
            var DailyTimeRangeM = GetListDailyTime();

            _context.DailyTimeRange.AddRange(DailyTimeRangeD);
            _context.DailyTimeRange.AddRange(DailyTimeRangeB);
            _context.DailyTimeRange.AddRange(DailyTimeRangeM);
            cocoD.DailyTimeRange = DailyTimeRangeD;
            cocoB.DailyTimeRange = DailyTimeRangeB;
            cocoM.DailyTimeRange = DailyTimeRangeM;

            _context.SaveChanges();



            Category CategorySoda = new() { Description = "Soda" };
            Category CategoryFood = new() { Description = "Food" };
            Category CategoryCleaning = new() { Description = "Cleaning" };
            Category CategoryBathroom = new() { Description = "Bathroom" };

            _context.Categories.AddRange(CategorySoda, CategoryFood, CategoryCleaning, CategoryBathroom);
            _context.Products.AddRange(
              new Product { Name = "Cold Ice Tea", Description = "", Price = 2.5, Category = CategorySoda },
              new Product { Name = "Coffee flavoured milk", Description = "", Price = 5.3, Category = CategorySoda },
              new Product { Name = "Nuke-Cola", Description = "", Price = 2.1, Category = CategorySoda },
              new Product { Name = "Sprute", Description = "", Price = 4, Category = CategorySoda },
              new Product { Name = "Slurm", Description = "", Price = 3.25, Category = CategorySoda },
              new Product { Name = "Diet Slurm", Description = "", Price = 3, Category = CategorySoda }
              );


            _context.Products.AddRange(
                new Product { Name = "Salsa Cookies", Description = "", Price = 0.75, Category = CategoryFood },
                new Product { Name = "Windmill Cookies", Description = "", Price = 1.33, Category = CategoryFood },
                new Product { Name = "Garlic - o - bread 2000", Description = "", Price = 2.15, Category = CategoryFood },
                new Product { Name = "LACTEL bread", Description = "", Price = 3.25, Category = CategoryFood },
                new Product { Name = "Ravioloches x12", Description = "", Price = 2, Category = CategoryFood },
                new Product { Name = "Ravioloches x48", Description = "", Price = 4.25, Category = CategoryFood },
                new Product { Name = "Milanga ganga", Description = "", Price = 3.35, Category = CategoryFood },
                new Product { Name = "Milanga ganga napo", Description = "", Price = 4.25, Category = CategoryFood }
                );

            _context.Products.AddRange(
                new Product { Name = "Atlantis detergent", Description = "", Price = 2.25, Category = CategoryCleaning },
                new Product { Name = "Virulanita", Description = "", Price = 0.75, Category = CategoryCleaning },
                new Product { Name = "Sponge, Bob", Description = "", Price = 1, Category = CategoryCleaning },
                new Product { Name = "Generic mop", Description = "", Price = 1.25, Category = CategoryCleaning }
                    );


            _context.Products.AddRange(
                new Product { Name = "Pure steel toilet paper", Description = "", Price = 1.25, Category = CategoryBathroom },
                new Product { Name = "Generic soap", Description = "", Price = 2, Category = CategoryBathroom },
                new Product { Name = "PANTONE shampoo", Description = "", Price = 2.75, Category = CategoryBathroom },
                new Product { Name = "Cabbagegate toothpaste", Description = "", Price = 2.25, Category = CategoryBathroom }
                    );
            Random rand = new Random();
            _context.SaveChanges();
            var stores = _context.Stores.ToList();
            var products = _context.Products.ToList();
            stores.ForEach(s =>
            products.ForEach(p =>
                _context.StockProducts.Add(new StockProduct { Product = p, Store = s, Quantity = rand.Next(0, 101) })
            ));
            _context.SaveChanges();
            var stocks = _context.StockProducts.ToList();
            var stockCero = stocks.Where(s => s.Store.Name == "COCO Bay" && "Diet Slurm,PANTONE shampoo,Pure steel toilet paper,Generic soap,Cabbagegate toothpaste".Contains(s.Product.Name))
                .Union(stocks.Where(s => s.Store.Name == "COCO Mall" && "Ravioloches x12,Ravioloches x48,Milanga ganga,Milanga ganga napo,Atlantis detergent,Virulanita, Sponge,Bob,Generic mop".Contains(s.Product.Name)).ToList())
                .Union(stocks.Where(s => s.Store.Name == "COCO Downtown" && "Sprute,Slurm,Atlantis detergent,Virulanita,Sponge, Bob,Generic mop,Pure steel toilet paper".Contains(s.Product.Name)).ToList())
                 .ToList();
            stockCero.ForEach(s => s.Quantity = 0);

            Cart cart = new Cart()
            {
                Client = new Customer() { Name = "John", Nic = "John666" },
                Store = cocoB
            };
            VoucherConfigure(_context, cocoB, cocoD ,cocoM, CategoryCleaning, CategoryBathroom, CategorySoda);

            _context.Add(cart);
            _context.SaveChanges();
        }

        private static void VoucherConfigure(MinimarketDataContext _context, Store cocoB, Store cocoD, Store cocoM, Category CategoryCleaning, Category CategoryBathroom, Category CategorySoda )
        {
            ///COCO Bay has:
            /////COCO1V1F8XOG1MZZ: 20% off on Wednesdays and Thursdays, on Cleaning products,from Jan 27th to Feb 13th
            VoucherCategory voucherBy1 = new VoucherCategory()
            {
                Code = "COCO1V1F8XOG1MZZ",
                Store = cocoB,
                DaysOfWeek = "Wednesdays,Thursdays",
                RangeDate = new RangeDate(new DateTime(2022, 1, 27), new DateTime(2022, 3, 13)),
                Discount = new PercentageDiscount() { Percentage = 20 }
            };
            voucherBy1.CategoriesToApply = new List<CategoriesDiscountToApply>() {
                new CategoriesDiscountToApply() { Category = CategoryCleaning, Voucher = voucherBy1 }};


            //  COCOKCUD0Z9LUKBN: Pay 2 take 3 on "Windmill Cookies" on up to 6 units, from Jan 24th to Feb 6th

            VoucherProduct voucherBay2 = new VoucherProduct()
            {
                Code = "COCOKCUD0Z9LUKBN",
                Store = cocoB,
                DaysOfWeek = "Wednesdays,Thursdays",
                RangeDate = new RangeDate(new DateTime(2022, 1, 24), new DateTime(2022, 2, 6)),
                 Discount = new PayTakeDiscount() { PayCount = 2, TakeCount = 3, Limit= 6 },
                ProductToApply = new List<ProductDiscountToApply>()
            };

            _context.Products.Where(p => p.Name == "Windmill Cookies").ToList().ForEach(p => 
                voucherBay2.ProductToApply.Add(new ProductDiscountToApply() { Voucher = voucherBay2 , Product= p })
            );

            //COCO Mall has:
            //COCOG730CNSG8ZVX: 10 % off on Bathroom and Sodas, from Jan 31th to Feb 9th
            VoucherCategory voucherMall = new VoucherCategory()
            {
                Code = "COCOG730CNSG8ZVX",
                Store = cocoM,
                DaysOfWeek = "",
                RangeDate = new RangeDate(new DateTime(2022, 1, 31), new DateTime(2022, 2, 9)),
                 Discount = new PercentageDiscount() { Percentage= 10}
            };
            voucherMall.CategoriesToApply = new List<CategoriesDiscountToApply>() {
                new CategoriesDiscountToApply() { Category = CategoryBathroom, Voucher = voucherMall },
                new CategoriesDiscountToApply() { Category = CategorySoda, Voucher = voucherMall } };


            //COCO Downtown has:
            //COCO2O1USLC6QR22: 30 % off on the second unit(of the same product), on "Nuka-Cola","Slurm" and "Diet Slurm",
            ////for all February
            VoucherProduct voucherDowntown1 = new VoucherProduct()
            {
                Code = "COCO2O1USLC6QR22",
                Store = cocoM,
                DaysOfWeek = "",
                RangeDate = new RangeDate(new DateTime(2022, 2, 1), new DateTime(2022, 2, 28)),
                ProductToApply= new List<ProductDiscountToApply>(),
                Discount = new PercentageSecundDiscount() { Percentage = 30 }
            };
            _context.Products.Where(p => p.Name == "Nuka-Cola"
                                            || p.Name == "Slurm"
                                            || p.Name == "Diet Slurm").ToList().ForEach(p =>
                                            voucherDowntown1.ProductToApply.Add(new ProductDiscountToApply() { Product = p, Voucher = voucherDowntown1 }));

            //COCO0FLEQ287CC05: 50 % off on the second unit(of the same product), on "Hang-yourself toothpaste", only on Mondays, first half of February.
            VoucherProduct voucherDowntown2 = new VoucherProduct()
            {
                Code = "COCO0FLEQ287CC05",
                Store = cocoM,
                DaysOfWeek = "Mondays",
                RangeDate = new RangeDate(new DateTime(2022, 2, 1), new DateTime(2022, 2, 14)),
                ProductToApply =  new  List<ProductDiscountToApply> (),
                Discount = new PercentageSecundDiscount() { Percentage = 50 }
            };
            _context.Products.Where(p =>  p.Name.Contains("toothpaste")).ToList().ForEach(p =>
                   voucherDowntown2.ProductToApply.Add(new ProductDiscountToApply() { Product = p, Voucher = voucherDowntown2 }));


            _context.CategoriesDiscountToApply.AddRange(voucherBy1.CategoriesToApply);
            _context.CategoriesDiscountToApply.AddRange(voucherMall.CategoriesToApply);
            _context.ProductDiscountToApply.AddRange(voucherDowntown1.ProductToApply);
            _context.ProductDiscountToApply.AddRange(voucherBay2.ProductToApply);
            _context.ProductDiscountToApply.AddRange(voucherDowntown2.ProductToApply);

            _context.Vouchers.AddRange(voucherBy1, voucherBay2, voucherMall, voucherDowntown1, voucherDowntown2);
            _context.SaveChanges();
        }

        private static List<DailyTimeRange> GetListDailyTime()
        {
            ///           
            /// Configure daily time range 
            return new List<DailyTimeRange>() {
            new DailyTimeRange() { DayOfWeek = DayOfWeek.Sunday.ToString(), HourFrom = new TimeSpan(8, 0, 0), HourTo = new TimeSpan(20, 30, 0) },
            new DailyTimeRange() { DayOfWeek = DayOfWeek.Monday.ToString(), HourFrom = new TimeSpan(8, 0, 0), HourTo = new TimeSpan(20, 30, 0) },
            new DailyTimeRange() { DayOfWeek = DayOfWeek.Tuesday.ToString(), HourFrom = new TimeSpan(8, 0, 0), HourTo = new TimeSpan(20, 30, 0) },
            new DailyTimeRange() { DayOfWeek = DayOfWeek.Wednesday.ToString(), HourFrom = new TimeSpan(8, 0, 0), HourTo = new TimeSpan(20, 30, 0) },
            new DailyTimeRange() { DayOfWeek = DayOfWeek.Thursday.ToString(), HourFrom = new TimeSpan(8, 0, 0), HourTo = new TimeSpan(20, 30, 0) },
            new DailyTimeRange() { DayOfWeek = DayOfWeek.Friday.ToString(), HourFrom = new TimeSpan(8, 0, 0), HourTo = new TimeSpan(20, 30, 0) },
            new DailyTimeRange() { DayOfWeek = DayOfWeek.Saturday.ToString(), HourFrom = new TimeSpan(8, 0, 0), HourTo = new TimeSpan(20, 30, 0) }
            };
        }
    }
}
