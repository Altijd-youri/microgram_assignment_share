namespace ProductRepo;

public class Product
{
    public long Id;
    public string Naam;
    public decimal Prijs;

    public Category Category;

    public Product()
    {
    }

    public Product(long id, string naam, decimal prijs, Category category)
    {
        Id = id;
        Naam = naam;
        Prijs = prijs;
        Category = category;
    }
}