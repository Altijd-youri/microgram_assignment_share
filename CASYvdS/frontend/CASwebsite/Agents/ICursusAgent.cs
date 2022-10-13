using CASwebsite.Models;

namespace CASwebsite.Agents;

public interface ICursusAgent
{
    IEnumerable<CursusInstantie> GetCursusInstanties(int week, int jaar);
    FileUpload UploadFile(FileUpload file);
}