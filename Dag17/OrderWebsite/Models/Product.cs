namespace OrderWebsite.Models;

public class Product
{
    public long id { get; set; }
    public string Naam { get; set; }
    public decimal Prijs { get; set; }

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