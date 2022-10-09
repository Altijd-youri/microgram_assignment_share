using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace OrderWebsite.Models;

public class Order
{
    public long Ordernummer { get; set; }
    public DateTime Datum { get; set; }
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