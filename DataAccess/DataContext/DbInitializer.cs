
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
                    new Store {  Name = "COCO 1", address ="" , hours=8, workdays="" },
                    new Store { Name = "COCO 2" , address = "", hours = 8,  workdays = "" },
                    new Store { Name = "COCO 3"  ,address = "", hours = 8,  workdays = "" }
                 );
                Category categoryTest = new Category() { description= "description" };
                _context.Categories.Add(categoryTest);
                _context.Products.AddRange(new Product { name = "product 1", description = "", price = 10 , category= categoryTest },
                    new Product { name = "product 2", description= "", price= 10, category= categoryTest },
                    new Product { name = "product 3", description = "", price = 10 , category= categoryTest }
                    );
                _context.SaveChanges();
            }
        }
    }
}
