using CASbackend.Models;

namespace CASbackend.Repository;

public interface ICursusRepository
{
    IEnumerable<CursusInstantie> GetAllCursusInstanties(int weeknummer);
}