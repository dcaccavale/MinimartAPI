
using Entities;
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
                Seed(_context);
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
            Store cocoD = new Store { Name = "COCO Downtown", Address = "" };
            Store cocoB = new Store { Name = "COCO Bay", Address = "" };
            Store cocoM = new Store { Name = "COCO Mall", Address = ""};


            _context.Stores.AddRange(cocoD,cocoB, cocoM );

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
                _context.StockProducts.Add(new StockProduct {Product = p, Store=s, Amoun = rand.Next(0, 101) })
            ));
            _context.SaveChanges();
            var stocks = _context.StockProducts.ToList();
            var stockCero= stocks.Where(s => s.Store.Name == "COCO Bay" && "Diet Slurm,PANTONE shampoo,Pure steel toilet paper,Generic soap,Cabbagegate toothpaste".Contains(s.Product.Name))
                .Union(stocks.Where(s => s.Store.Name == "COCO Mall" && "Ravioloches x12,Ravioloches x48,Milanga ganga,Milanga ganga napo,Atlantis detergent,Virulanita, Sponge,Bob,Generic mop".Contains(s.Product.Name)).ToList())
                .Union(stocks.Where(s => s.Store.Name == "COCO Downtown" && "Sprute,Slurm,Atlantis detergent,Virulanita,Sponge, Bob,Generic mop,Pure steel toilet paper".Contains(s.Product.Name)).ToList())
                 .ToList();
            stockCero.ForEach(s => s.Amoun = 0);
            _context.SaveChanges();
        }
        
    }
}
