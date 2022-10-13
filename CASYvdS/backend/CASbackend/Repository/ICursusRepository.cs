using CASbackend.Models;

namespace CASbackend.Repository;

public interface ICursusRepository
{
    IEnumerable<CursusInstantie> GetAllCursusInstanties(int week, int jaar);

    OutFileUpload CreateCursusInstanties(IEnumerable<CursusInstantie> instanties);
}