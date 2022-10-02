namespace ProductRepo;

public class Product
{
    public Product(long id, string naam, decimal prijs)
    {
        Id = id;
        Naam = naam;
        Prijs = prijs;
    }

    public long Id;
    public string Naam;
    public decimal Prijs;
}