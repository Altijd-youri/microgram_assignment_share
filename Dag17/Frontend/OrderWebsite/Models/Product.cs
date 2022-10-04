namespace OrderWebsite.Models;

public class Product
{
    public long id { get; }
    public string Naam { get; }
    public decimal Prijs { get; }

    public Product()
    {
    }

    public Product(long id, string naam, decimal prijs)
    {
        this.id = id;
        Naam = naam;
        Prijs = prijs;
    }
}