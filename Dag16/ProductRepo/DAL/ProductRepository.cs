using Microsoft.EntityFrameworkCore;

namespace ProductRepo.DAL;

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

    public void UpdateProduct(Product product)
    {
        using var context = new ProductContext(_options);
        var productToChange = context.Products
            .Include(p => p.Category)
            .Single(p => p.Id == 110);

        //productToChange.Id = product.Id;
        productToChange.Naam = product.Naam;
        productToChange.Prijs = product.Prijs;
        var existingCategory = context.Categories.Find(product.Category.Id);
        if (existingCategory == null)
        {
            productToChange.Category = product.Category;
        }
        else
        {
            productToChange.Category = existingCategory;
        }




        context.Products.Update(productToChange);
        context.SaveChanges();
    }
}