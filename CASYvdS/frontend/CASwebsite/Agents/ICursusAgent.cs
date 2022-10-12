using CASwebsite.Models;

namespace CASwebsite.Agents;

public interface ICursusAgent
{
    IEnumerable<CursusInstantie> GetCursusInstanties(int weeknummer);
    FileUpload UploadFile(FileUpload file);
}