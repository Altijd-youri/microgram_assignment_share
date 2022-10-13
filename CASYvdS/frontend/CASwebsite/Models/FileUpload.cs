using System.ComponentModel.DataAnnotations;

namespace CASwebsite.Models;

public record FileUpload
{
    public bool IsValid { get; set; } = true;
    public bool IsValidated { get; set; }
    public byte[] Content { get; set; }
    public string Message { get; set;  }
    public int ErrorPosition { get; set; }
    public int Duplicates { get; set;  }
    public int CursusInserts { get; set;  }
    public int InstantieInserts { get; set;  }

    public DateTime BeginFilter { get; set; } = DateTime.Today.AddMonths(-6);

    public DateTime EindFilter { get; set; } = DateTime.Today;
    
    [Required(ErrorMessage = "Bestand kan niet worden gevonden.")]
    public IFormFile File { get; set;  }
}