using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using CASbackend.Models;
using CASbackend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CASbackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UploadController : ControllerBase
{
    private static readonly Regex TitelRegex = new (@"^Titel: (?<Value>.*)$");
    private static readonly Regex CodeRegex = new (@"^Cursuscode: (?<Value>.*)$");
    private static readonly Regex DuurRegex = new (@"^Duur: (?<Value>.*) dagen$");
    private static readonly Regex DatumRegex = new (@"^Startdatum: (?<Value>.\d{1,2}\/\d{1,2}\/\d{4})(?:\n{2}|$)$");
    private static readonly Regex LineRegex = new (@"^(?<Value>)$");
    private static readonly CultureInfo CultureInfo = new("nl-NL");
    
    private readonly ICursusRepository _CursusRepository;

    public UploadController(ICursusRepository cursusRepository)
    {
        _CursusRepository = cursusRepository;
    }

    private string[] SplitFileIntoLines(byte[] fileContent)
    {
        return Encoding.Default.GetString(fileContent)
            .Replace("\r\n", "\n")
            .Replace("\r", "\n")
            .Split("\n");
    }
    
    [HttpPost]
    public FileUpload UploadFile(FileUpload file)
    {
        FileUpload status = new FileUpload();

        string[] regels = SplitFileIntoLines(file.Content);
        
        List<CursusInstantie> instanties = new();
        CursusInstantieBuilder builder = CursusInstantieBuilder.Get();
        try
        {
            string MatchOrThrowInvalidLineException(Regex regex, string regel, int regelnummer) {
                Match match = regex.Match(regel);
                if (!match.Success) throw new InvalidLineException(regelnummer);
                return match.Groups["Value"].Value;
            }
            
            for (var i = 0; i < regels.Length; i++)
            {
                var regelnummer = i + 1;
                var positionInPattern = regelnummer % 5;
                var regel = regels[i];
                switch (positionInPattern)
                {
                    case 1:
                        builder.AddTitel(
                            MatchOrThrowInvalidLineException(TitelRegex, regel, regelnummer)
                        );
                        break;
                    case 2:
                        builder.AddCursusCode(
                            MatchOrThrowInvalidLineException(CodeRegex, regel, regelnummer)
                            );
                        break;
                    case 3:
                        builder.AddDuur(
                            int.Parse(
                                MatchOrThrowInvalidLineException(DuurRegex, regel, regelnummer)
                            )
                        );
                        break;
                    case 4:
                        builder.AddStartDatum(
                            DateTime.Parse(
                                MatchOrThrowInvalidLineException(DatumRegex, regel, regelnummer), 
                                CultureInfo
                            )
                        );
                        break;
                    case 0:
                        MatchOrThrowInvalidLineException(LineRegex, regel, regelnummer);
                        instanties.Add(builder.Build());
                        break;
                }
            }
            status = _CursusRepository.CreateCursusInstanties(instanties);
            status.IsValid = true;
        }
        catch (InvalidLineException e)
        {
            status.ErrorPosition = e.Line;
            status.IsValid = false;
        }
        return status;
    }
}