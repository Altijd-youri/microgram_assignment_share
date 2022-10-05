namespace ProductRepo;

public class Category
{
    public long Id { get; }
    public string Naam { get;  }

    public IEnumerable<Product> Products { get; set; } = new List<Product>();

    public Category()
    {
    }

    public Category(long id, string naam)
    {
        Id = id;
        Naam = naam;
    }
}