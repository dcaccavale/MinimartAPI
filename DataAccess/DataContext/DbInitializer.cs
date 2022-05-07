
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

                if (_context.Stores.Any())
                {
                    return;
                }

                _context.Stores.AddRange(
                    new Store {  Name = "COCO Downtown", Address ="" , Hours=8, Workdays="" },
                    new Store { Name = "COCO Bay", Address = "", Hours = 8, Workdays = "" },
                    new Store { Name = "COCO Mall", Address = "", Hours = 8, Workdays = "" }
                 );
                Category categorySoda = new () { description= "Soda" };
                Category categoryFood = new () { description = "Food" };
                Category categoryCleaning = new () { description = "Cleaning" };
                Category categoryBathroom = new () { description = "Bathroom" };

                _context.Categories.Add(categorySoda);
                _context.Products.AddRange(
                    new Product { name = "Cold Ice Tea", description = "", price = 2.5 , category= categorySoda },
                    new Product { name = "Coffee flavoured milk", description= "", price= 5.3, category= categorySoda },
                    new Product { name = "Nuke-Cola", description = "", price = 2.1 , category= categorySoda },
                    new Product { name = "Sprute", description = "", price = 4, category = categorySoda },
                    new Product { name = "Slurm", description = "", price = 3.25, category = categorySoda },
                    new Product { name = "Diet Slurm", description = "", price = 3, category = categorySoda }
                    );
                _context.Categories.Add(categoryFood);
                _context.Products.AddRange(
                    new Product { name = "Salsa Cookies", description = "", price = 0.75, category = categorySoda },
                    new Product { name = "Windmill Cookies", description = "", price = 1.33, category = categorySoda },
                    new Product { name = "Garlic - o - bread 2000", description = "", price = 2.15, category = categorySoda },
                    new Product { name = "LACTEL bread", description = "", price = 3.25, category = categorySoda },
                    new Product { name = "Ravioloches x12", description = "", price = 2, category = categorySoda },
                    new Product { name = "Ravioloches x48", description = "", price = 4.25, category = categorySoda },
                      new Product { name = "Milanga ganga", description = "", price = 3.35, category = categorySoda },
                        new Product { name = "Milanga ganga napo", description = "", price = 4.25, category = categorySoda }
                    );
                _context.Categories.Add(categoryCleaning);
                _context.Products.AddRange(
                    new Product { name = "Atlantis detergent", description = "", price = 2.25, category = categorySoda },
                    new Product { name = "Virulanita", description = "", price = 0.75, category = categorySoda },
                    new Product { name = "Sponge, Bob", description = "", price = 1, category = categorySoda },
                    new Product { name = "Generic mop", description = "", price = 1.25, category = categorySoda }
                        );
                _context.Categories.Add(categoryBathroom);
                _context.Products.AddRange(
                    new Product { name = "Pure steel toilet paper", description = "", price = 1.25, category = categorySoda },
                    new Product { name = "Generic soap", description = "", price = 2, category = categorySoda },
                    new Product { name = "PANTONE shampoo", description = "", price = 2.75, category = categorySoda },
                    new Product { name = "Cabbagegate toothpaste", description = "", price = 2.25, category = categorySoda }
                        );

              

                _context.SaveChanges();
            }
        }
        
    }
}
