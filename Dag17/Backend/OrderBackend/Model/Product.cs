namespace OrderBackend.Models;

public class Product
{
    public long Id { get; set; }
    public string Naam { get; set;  }
    public decimal Prijs { get; set;  }

    public Product()
    {
    }

    public Product(long id, string naam, decimal prijs)
    {
        this.Id = id;
        Naam = naam;
        Prijs = prijs;
    }
}