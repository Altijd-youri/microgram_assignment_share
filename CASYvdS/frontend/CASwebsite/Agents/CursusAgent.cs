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
    
    public IEnumerable<CursusInstantie> GetCursusInstanties(int weeknummer)
    {
        var result = _baseUrl
            .AppendPathSegment($"api/cursus/week/{weeknummer}")
            .GetJsonAsync<IEnumerable<CursusInstantie>>()
            .Result;
        return result;
    }
}