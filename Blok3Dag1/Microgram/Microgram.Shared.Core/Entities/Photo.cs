using System.ComponentModel.DataAnnotations;

namespace Microgram.Shared.Core.Entities;

public class Photo
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Post title is mandatory.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Upload a photo.")]
    public byte[] PhotoFile { get; set; }
    
    [Required(ErrorMessage = "Image type couldn't be set.")]
    public string ImageMimeType { get; set; }
    
    [Required(ErrorMessage = "Description is mandatory.")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Date couldn't be set.")]
    public DateTime CreatedDate { get; set; }
    
    [Required(ErrorMessage = "Username is mandatory.")]
    public string UserName { get; set; }
}