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
    
    public IEnumerable<CursusInstantie> GetCursusInstanties(int week, int jaar)
    {
        var result = _baseUrl
            .AppendPathSegment($"api/cursus/{jaar}/{week}")
            .GetJsonAsync<IEnumerable<CursusInstantie>>()
            .Result;
        return result;
    }

    public FileUpload UploadFile(FileUpload file)
    {
        var result = _baseUrl.AppendPathSegment("api/upload")
            .PostJsonAsync(file)
            .ReceiveJson<FileUpload>()
            .Result;

        return result;
    }
}