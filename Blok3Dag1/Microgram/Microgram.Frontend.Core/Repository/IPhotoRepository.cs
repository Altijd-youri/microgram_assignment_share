using Microgram.Frontend.Core.Entities;

namespace Microgram.Frontend.Core.Repository;

public interface IPhotoRepository
{
    public Task<List<PhotoEntity>> GetPhotoList();

    public Task<PhotoEntity> AddPhoto(PhotoEntity photo);
    public Task<PhotoEntity> UpdatePhoto(PhotoEntity photo);
    public Task<PhotoEntity> FindById(int id);
    public Task DeletePhoto(PhotoEntity photo);
}