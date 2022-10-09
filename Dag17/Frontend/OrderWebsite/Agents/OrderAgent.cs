using Flurl;
using Flurl.Http;
using OrderWebsite.Models;

namespace OrderWebsite.Agents;

public class OrderAgent : IOrderAgent
{
    public readonly string _baseUrl;

    public OrderAgent(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public IEnumerable<Order> GetOrderList()
    {
        var result = _baseUrl
            .AppendPathSegment("api/order")
            .GetJsonAsync<IEnumerable<Order>>()
            .Result;
        return result;
    }

    public Order GetOrder(long id)
    {
        throw new NotImplementedException();
    }
}