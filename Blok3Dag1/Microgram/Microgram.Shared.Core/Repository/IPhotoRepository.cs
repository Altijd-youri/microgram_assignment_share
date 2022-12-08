using Microgram.Shared.Core.Entities;

namespace Microgram.Shared.Core.Repository;

public interface ICommentRepository
{
    public Task<List<Comment>> GetCommentByPhoto(Photo photo);

    public Task<Comment> UpdateComment(Comment comment);
    public Task<Comment> CreateComment(Comment comment);
    public Task<Comment> FindById(string id);
    public Task DeleteComment(Comment comment);
}