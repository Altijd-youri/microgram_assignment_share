using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProductRepo;
using ProductRepo.DAL;

namespace productRepo.Test;

[TestClass]
public class ProductRepositoryTest
{
    private SqliteConnection _connection;
    private DbContextOptions<ProductContext> _options;
    
    [TestInitialize]
    public void TestInitialize()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        _options = new DbContextOptionsBuilder<ProductContext>()
            .UseSqlite(_connection)
            .Options;

        using (var context = new ProductContext(_options))
        {
            context.Database.EnsureCreated();
        }
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _connection.Close();
    }
    
    [TestMethod]
    public void FindAllProductsTest()
    {
        using (var context = new ProductContext(_options))
        {
            Product[] products =
            {
                new (101, "Edam Cheese", 4.20M),
                new (110, "Gouda Cheese", 6.69M),
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
        var sut = new ProductRepository(_options);

        IEnumerable<Product> result = sut.FindAllProducts();
        
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(p => p.Naam == "Edam Cheese"));
        Assert.IsTrue(result.Any(p => p.Naam == "Gouda Cheese"));
    }

    [TestMethod]
    public void FindProductTest_ById_RetrieveCorrectProduct()
    {
        using (var context = new ProductContext(_options))
        {
            Product[] products =
            {
                new (101, "Edam Cheese", 4.20M),
                new (110, "Gouda Cheese", 6.69M),
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
        var sut = new ProductRepository(_options);

        Product result = sut.FindProduct(110);
        
        Assert.IsTrue(result.Prijs == 6.69M && result.Id == 110 && result.Naam == "Gouda Cheese");
    }
    
    [TestMethod]
    public void DeleteProduct_ById_NumberOfProductsIsDecreasedByOne()
    {
        using (var context = new ProductContext(_options))
        {
            Product[] products =
            {
                new (101, "Edam Cheese", 4.20M),
                new (110, "Gouda Cheese", 6.69M),
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
        var sut = new ProductRepository(_options);

        sut.DeleteProduct(101);

        IEnumerable<Product> allProducts = sut.FindAllProducts();
        int numberOfProducts = allProducts.Count();
        Product firstProduct = allProducts.First();
        Assert.AreEqual(1, numberOfProducts);
        Assert.IsTrue(firstProduct.Prijs == 6.69M && firstProduct.Id == 110 && firstProduct.Naam == "Gouda Cheese");
    }
    
    [TestMethod]
    public void CreateProduct_ActuallyAddsProduct_ToDatabase()
    {
        var sut = new ProductRepository(_options);
        Product productToCreate = new Product(102, "Edam Cheese", 5.99M);
        
        sut.CreateProduct(productToCreate);

        IEnumerable<Product> allProducts = sut.FindAllProducts();
        int numberOfProducts = allProducts.Count();
        Product firstProduct = allProducts.First();
        Assert.AreEqual(1, numberOfProducts);
        Assert.IsTrue(firstProduct.Prijs == 5.99M && firstProduct.Id == 102 && firstProduct.Naam == "Edam Cheese");
    }
}