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
    // TODO: Link to Category   *--1
    // TODO Link to vendor      *--1
}