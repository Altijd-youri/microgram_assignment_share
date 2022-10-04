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

    private Category defaultCategory = new Category(200, "Cheese");
    
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
                new (101, "Edam Cheese", 4.20M, defaultCategory),
                new (110, "Gouda Cheese", 6.69M, defaultCategory),
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
                new (101, "Edam Cheese", 4.20M, defaultCategory),
                new (110, "Gouda Cheese", 6.69M, defaultCategory),
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
                new (101, "Edam Cheese", 4.20M, defaultCategory),
                new (110, "Gouda Cheese", 6.69M, defaultCategory),
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
        Product productToCreate = new Product(102, "Edam Cheese", 5.99M, defaultCategory);
        
        sut.CreateProduct(productToCreate);

        IEnumerable<Product> allProducts = sut.FindAllProducts();
        int numberOfProducts = allProducts.Count();
        Product firstProduct = allProducts.First();
        Assert.AreEqual(1, numberOfProducts);
        Assert.IsTrue(firstProduct.Prijs == 5.99M && firstProduct.Id == 102 && firstProduct.Naam == "Edam Cheese");
    }
    
    [TestMethod]
    public void UpdateProduct_updatesProduct_ToDatabase()
    {
        using (var context = new ProductContext(_options))
        {
            Product[] products =
            {
                new (110, "Gouda Cheese", 6.69M, defaultCategory),
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
        var sut = new ProductRepository(_options);
        Product productToUpdate = new(110, "Gouda Cheese 48%", 7.70M, defaultCategory);

        sut.UpdateProduct(productToUpdate);

        Product result = sut.FindProduct(110);
        Assert.IsTrue(result.Prijs == 7.70M && result.Id == 110 && result.Naam == "Gouda Cheese 48%");
    }
    
    [TestMethod]
    public void UpdateProduct_updatesCategory_ToDatabase()
    {
        using (var context = new ProductContext(_options))
        {
            Category category = new Category(200, "Cheese");
            Product product = new(110, "Gouda Cheese", 6.69M, category);
            context.Products.Add(product);
            context.SaveChanges();
        }
        var sut = new ProductRepository(_options);
        
        Category newCategory = new Category(500, "Dairy");
        Product productToUpdate = new(110, "Gouda Cheese", 6.69M, newCategory);
        sut.UpdateProduct(productToUpdate); // TODO: Concurrency issue 
        // The database operation was expected to affect 1 row(s), but actually affected 0 row(s);
        // data may have been modified or deleted since entities were loaded.
        // See http://go.microsoft.com/fwlink/?LinkId=527962 for information on
        // understanding and handling optimistic concurrency exceptions.
        
        using (var context = new ProductContext(_options))
        {
            var result = context.Products
                .Include(p => p.Category)
                .Single(p => p.Id == 110);
            // Het concurrency issues heeft volgens mij te maken met de include, maar ik kan niet echt achterhalen waarom
            // Dit lijkt mij een meer voorkomende situatie wanneer er twee objecten met een één op veel relatie gekoppeld worden.
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Category.Id == 500 && result.Category.Naam == "Dairy");
        }
    }
}