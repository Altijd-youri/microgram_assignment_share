
using Microgram.Shared.Core.Entities;

namespace Microgram.Shared.Core.Repository;

public interface IPhotoRepository
{
    public Task<List<Photo>> GetPhotoList();

    public Task<Photo> AddPhoto(Photo photo);
    public Task<Photo> UpdatePhoto(Photo photo);
    public Task<Photo> FindById(int id);
    public Task DeletePhoto(Photo photo);
}