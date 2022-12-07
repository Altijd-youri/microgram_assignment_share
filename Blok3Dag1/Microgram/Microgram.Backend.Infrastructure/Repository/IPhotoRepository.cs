using Microgram.Backend.Core.Enitities;

namespace Microgram.Backend.Infrastructure.Repository;

public interface IPhotoRepository
{
    public Task<List<PhotoEntity>> GetPhotoList();

    public Task<PhotoEntity> AddPhoto(PhotoEntity photo);
    public Task<PhotoEntity> UpdatePhoto(PhotoEntity photo);
    public Task<PhotoEntity> FindById(int id);
    public Task DeletePhoto(PhotoEntity photo);
}