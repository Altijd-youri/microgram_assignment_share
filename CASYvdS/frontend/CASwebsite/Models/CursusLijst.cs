using System.ComponentModel.DataAnnotations;

namespace CASwebsite.Models;

public class CursusLijst
{
    public int Weeknummer { get; set; }
    public IEnumerable<CursusInstantie> CursusInstanties { get; set; }

    public CursusLijst()
    {
    }

    public CursusLijst(int weeknummer, IEnumerable<CursusInstantie> cursusInstanties)
    {
        Weeknummer = weeknummer;
        CursusInstanties = cursusInstanties;
    }
}