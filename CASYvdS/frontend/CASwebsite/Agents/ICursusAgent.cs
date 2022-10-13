using CASwebsite.Models;

namespace CASwebsite.Agents;

public interface ICursusAgent
{
    IEnumerable<CursusInstantie> GetCursusInstanties(int week, int jaar);
    
    CursusInstantie GetCursusInstantie(string code, string datum);
    FileUpload UploadFile(FileUpload file);
    
}