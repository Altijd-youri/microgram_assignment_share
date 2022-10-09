namespace OrderBackend.Models;

public class Order
{
    public long Ordernummer { get; set; }
    public DateTime Datum { get; set; }
    public List<OrderRow> OrderRows { get; set; }

    public Order()
    {
    }
    
    public Order(DateTime datum)
    {
        Datum = datum;
        OrderRows = new List<OrderRow>();
    }
    public Order(DateTime datum, long ordernummer)
    {
        Datum = datum;
        Ordernummer = ordernummer;
        OrderRows = new List<OrderRow>();
    }
}