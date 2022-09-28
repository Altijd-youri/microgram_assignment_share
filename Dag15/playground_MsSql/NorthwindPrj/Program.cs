using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NorthwindPrj.Models;

namespace NorthwindPrj;

class Program
{
    public static void Main(string[] args)
    {
        string connectionString = "Server=localhost,14330;Database=NorthWind;User=SA;Password=secrets_MoreLength1;";

        DbContextOptions<NorthWindContext> options = new DbContextOptionsBuilder<NorthWindContext>()
            // .LogTo(Console.WriteLine, LogLevel.Information)
            .UseSqlServer(connectionString)
            .Options;
        
        DbContextOptions<NorthWindContext> optionsLazy = new DbContextOptionsBuilder<NorthWindContext>()
            .LogTo(Console.WriteLine, LogLevel.Information)
            .UseSqlServer(connectionString+"MultipleActiveResultSets=true;")
            .UseLazyLoadingProxies()
            .Options;

        using (var context = new NorthWindContext(options))
        {
            var allExpensiveProducts = from product in context.Products
                where product.UnitPrice > 100M
                select new { Name=product.ProductName, Price=product.UnitPrice };
            
            var allBeverages = from product in context.Products
                where product.Category.CategoryName == "Beverages"
                select new { Name=product.ProductName, Quantity=product.QuantityPerUnit };

            Console.WriteLine("Expensive products:");
            foreach (var product in allExpensiveProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }
            Console.WriteLine();
            
            Console.WriteLine("all beverages:");
            foreach (var product in allBeverages)
            {
                Console.WriteLine($"{product.Name}  - {product.Quantity}");
            }
            Console.WriteLine();
    
        }

        using (var context = new NorthWindContext(optionsLazy))
        {
            var allExpensiveProductsImproved = from product in context.Products
                    .Include(p => p.Category)
                where product.UnitPrice > 100M
                select new { Name=product.ProductName, Price=product.UnitPrice, Category=product.Category.CategoryName, Supplier=product.Supplier.CompanyName };
            
            var allExpensiveProductsMixed = from product in context.Products
                    .Include(p => p.Category)
                where product.UnitPrice > 100M
                select product;

            Console.WriteLine("Expensive products (mixed Query):");
            foreach (var product in allExpensiveProductsMixed)
            {
                Console.WriteLine($"{product.ProductName} | {product.UnitPrice} | {product.Category?.CategoryName} | {product.Supplier?.CompanyName}");
            }
            Console.WriteLine();
            
            Console.WriteLine("Expensive products (improved Query):");
            foreach (var product in allExpensiveProductsImproved)
            {
                Console.WriteLine($"{product.Name} | {product.Price} | {product.Category} | {product.Supplier}");
            }
            Console.WriteLine();
        }
    }
}