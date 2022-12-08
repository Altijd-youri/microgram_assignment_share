using Microgram.Frontend.Core.Entities;
using Microgram.Frontend.Core.Repository;
using Flurl;
using Flurl.Http;

namespace Microgram.Frontend.Infrastructure.Repository;

public class PhotoBackendRepository : IPhotoRepository
{
    private readonly string _baseUrl;

    public PhotoBackendRepository(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public async Task<List<PhotoEntity>> GetPhotoList()
    {
        var result = await _baseUrl
            .AppendPathSegment("photo")
            .GetJsonAsync<List<PhotoEntity>>();
        return result ?? new List<PhotoEntity>();
    }

    public async Task<PhotoEntity> AddPhoto(PhotoEntity photo)
    {
        var result = await _baseUrl
            .AppendPathSegment("photo")
            .PostJsonAsync(photo)
            .ReceiveJson<PhotoEntity>();
        if (result is null)
        {
            throw new ArgumentException("Photo is not added.");
        }
        return result;
    }

    public async Task<PhotoEntity> UpdatePhoto(PhotoEntity photo)
    {
        var result = await _baseUrl
            .AppendPathSegment("photo")
            .AppendPathSegment(photo.Id)
            .PatchJsonAsync(photo)
            .ReceiveJson<PhotoEntity>();
        if (result is null)
        {
            throw new ArgumentException("Photo is not updated.");
        }
        return result;
    }

    public async Task<PhotoEntity> FindById(int id)
    {
        var result = await _baseUrl
            .AppendPathSegment("photo")
            .AppendPathSegment(id)
            .GetJsonAsync<PhotoEntity>();
        if (result is null)
        {
            throw new ArgumentException("Photo is not added.");
        }
        return result;
    }

    public async Task DeletePhoto(PhotoEntity photo)
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