namespace CASbackend.Models;

public record InFileUpload
{
    public byte[] Content { get; set; }
    
    public DateTime BeginFilter { get; set; }
    
    public DateTime EindFilter { get; set; }
}