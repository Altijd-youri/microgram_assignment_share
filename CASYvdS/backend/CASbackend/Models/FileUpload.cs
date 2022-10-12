namespace CASbackend.Models;

public record FileUpload
{
    public bool IsValid { get; set; }
    
    public bool IsValidated { get; set; } = true;
    
    public byte[] Content { get; set; }
    public int Duplicates { get; set; }
    public int CursusInserts { get; set; }
    public int InstantieInserts { get; set; }
    
    public int ErrorPosition { get; set; }
}