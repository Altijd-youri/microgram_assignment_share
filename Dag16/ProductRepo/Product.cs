namespace ProductRepo;

public class Product
{
    public long Id  { get; set; }
    public string Naam  { get; set; }
    public decimal Prijs  { get; set; }

    public Category Category { get; set; }

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