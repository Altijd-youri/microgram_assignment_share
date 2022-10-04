using System.ComponentModel.DataAnnotations;

namespace OrderWebsite.Models;

public class Order
{
    public long Ordernummer { get; set; }
    [DataType(DataType.Date)]
    public DateTime Datum { get; set; }
    public List<OrderRow> OrderRows { get; set; } = new ();

    public Order()
    {
    }

    public Order(DateTime datum, long ordernummer)
    {
        Datum = datum;
        Ordernummer = ordernummer;
    }

    public decimal GetOrderTotaal()
    {
        return OrderRows.Select(or => or.getRijTotaal()).Sum();
    }
}