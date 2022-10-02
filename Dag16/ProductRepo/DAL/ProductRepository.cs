using Microsoft.EntityFrameworkCore;
using ProductRepo.DAL;

namespace ProductRepo;

public class ProductRepository
{
    private readonly DbContextOptions<ProductContext> _options;

    public ProductRepository(DbContextOptions<ProductContext> options)
    {
        _options = options;
    }

    public IEnumerable<Product> FindAllProducts()
    {
        using var context = new ProductContext(_options);
        return context.Products.ToList();
    }

    public Product FindProduct(long Id)
    {
        using var context = new ProductContext(_options);
        return context.Products.Single(p => p.Id == Id);
    }

    public void DeleteProduct(long Id)
    {
        using var context = new ProductContext(_options);
        Product productToRemove = FindProduct(Id);
        context.Products.Remove(productToRemove);
        context.SaveChanges();
    }

    public void CreateProduct(Product productToCreate)
    {
        using var context = new ProductContext(_options);
        context.Products.Add(productToCreate);
        context.SaveChanges();
    }

    public void UpdateProduct(Product productToUpdate)
    {
        using var context = new ProductContext(_options);
        context.Products.Update(productToUpdate);
        context.SaveChanges();
    }
}