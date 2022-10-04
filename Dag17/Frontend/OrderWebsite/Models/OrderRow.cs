namespace OrderWebsite.Models;

public class OrderRow
{
    public long Id { get; }
    public Product Product { get; }
    public int Aantal { get; }

    public OrderRow()
    {
    }

    public OrderRow(long id, Product product, int aantal)
    {
        Id = id;
        Product = product;
        Aantal = aantal;
    }

    public decimal getRijTotaal()
    {
        return Product.Prijs * Aantal;
    }
}