using CASwebsite.Models;
using Flurl;
using Flurl.Http;

namespace CASwebsite.Agents;

public class CursusAgent : ICursusAgent
{
    private readonly string _baseUrl;

    public CursusAgent(string baseUrl)
    {
        _baseUrl = baseUrl;
    }
    
    public IEnumerable<CursusInstantie> GetCursusInstanties()
    {
        var result = _baseUrl
            .AppendPathSegment("api/cursus")
            .GetJsonAsync<IEnumerable<CursusInstantie>>()
            .Result;
        return result;
    }
}