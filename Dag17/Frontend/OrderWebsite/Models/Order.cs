using System.ComponentModel.DataAnnotations;

namespace OrderWebsite.Models;

public class Order
{
    public long Ordernummer { get; }
    [DataType(DataType.Date)]
    public DateTime Datum { get; }
    public List<OrderRow> OrderRows { get; set; }

    public Order()
    {
    }

    public Order(DateTime datum, long ordernummer)
    {
        Datum = datum;
        Ordernummer = ordernummer;
        OrderRows = new List<OrderRow>();
    }

    public decimal GetOrderTotaal()
    {
        return OrderRows.Select(or => or.getRijTotaal()).Sum();
    }
}