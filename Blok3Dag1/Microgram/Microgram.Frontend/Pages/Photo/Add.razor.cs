using Microgram.Frontend.Core.Entities;
using Microgram.Frontend.Core.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Microgram.Frontend.Pages.Photo;

public partial class Add
{
    [Inject]
    private IPhotoRepository _photoRepository { get; set; }

    private PhotoEntity _photo = new();
    private bool _formSuccess;

    private async Task Submit(EditContext context)
    {
        _photo.CreatedDate = DateTime.Now;
        _formSuccess = true;
        StateHasChanged();
        await _photoRepository.AddPhoto(_photo);
        _photo = new PhotoEntity();
    }
    
    private async Task UploadFile(IBrowserFile file)
    {
        _photo.ImageMimeType = file.ContentType;
        _photo.CreatedDate = @DateTime.Now;
        
        using var streamReader = new MemoryStream();
        await file.OpenReadStream().CopyToAsync(streamReader);
        _photo.PhotoFile = streamReader.ToArray();
        StateHasChanged();
    }
}