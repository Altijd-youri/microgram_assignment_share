using Newtonsoft.Json;

namespace OrderBackend.DataTransferObject;

public class OrderTopLevelDto
{
    public long Ordernummer { get; set; }
    [JsonConverter(typeof(DateTime))]
    public DateTime Datum { get; set; }

    public OrderTopLevelDto(long ordernummer, DateTime datum)
    {
        Ordernummer = ordernummer;
        Datum = datum;
    }
};