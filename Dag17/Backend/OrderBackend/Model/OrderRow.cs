namespace OrderBackend.Models;

public class OrderRow
{
    public long Id { get; set; }
    public Product Product { get; set; }
    public int Aantal { get; set;  }

    public OrderRow()
    {
    }

    public OrderRow(long id, Product product, int aantal)
    {
        Id = id;
        Product = product;
        Aantal = aantal;
    }
}