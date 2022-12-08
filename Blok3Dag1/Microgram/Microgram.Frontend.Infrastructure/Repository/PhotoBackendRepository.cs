using Flurl;
using Flurl.Http;
using Microgram.Shared.Core.Entities;
using Microgram.Shared.Core.Repository;

namespace Microgram.Frontend.Infrastructure.Repository;

public class PhotoBackendRepository : IPhotoRepository
{
    private readonly string _baseUrl;

    public PhotoBackendRepository(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public async Task<List<Photo>> GetPhotoList()
    {
        var result = await _baseUrl
            .AppendPathSegment("photo")
            .GetJsonAsync<List<Photo>>();
        return result ?? new List<Photo>();
    }

    public async Task<Photo> AddPhoto(Photo photo)
    {
        var result = await _baseUrl
            .AppendPathSegment("photo")
            .PostJsonAsync(photo)
            .ReceiveJson<Photo>();
        if (result is null)
        {
            throw new ArgumentException("Photo is not added.");
        }
        return result;
    }

    public async Task<Photo> UpdatePhoto(Photo photo)
    {
        var result = await _baseUrl
            .AppendPathSegment("photo")
            .AppendPathSegment(photo.Id)
            .PatchJsonAsync(photo)
            .ReceiveJson<Photo>();
        if (result is null)
        {
            throw new ArgumentException("Photo is not updated.");
        }
        return result;
    }

    public async Task<Photo> FindById(int id)
    {
        var result = await _baseUrl
            .AppendPathSegment("photo")
            .AppendPathSegment(id)
            .GetJsonAsync<Photo>();
        if (result is null)
        {
            throw new ArgumentException("Photo is not added.");
        }
        return result;
    }

    public async Task DeletePhoto(Photo photo)
    {
        var result = await _baseUrl
            .AppendPathSegment("photo")
            .AppendPathSegment(photo.Id)
            .DeleteAsync();
        if (result is null)
        {
            throw new ArgumentException("Photo is not deleted.");
        }
    }
}