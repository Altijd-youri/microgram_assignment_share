using CASwebsite.Models;

namespace CASwebsite.Agents;

public interface ICursusAgent
{
    IEnumerable<CursusInstantie> GetCursusInstanties();
}