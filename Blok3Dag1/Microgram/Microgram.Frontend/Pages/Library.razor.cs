using Microgram.Frontend.Core.Entities;
using Microgram.Frontend.Core.Repository;
using Microsoft.AspNetCore.Components;

namespace Microgram.Frontend.Pages;

public partial class Library
{
    public int GridSpacing { get; set; } = 2;
    
    
    [Inject]
    private IPhotoRepository PhotoRepository { get; set; }

    private List<PhotoEntity> _photos = new ();

    protected override async Task OnInitializedAsync()
    {
        _photos = await PhotoRepository.GetPhotoList();
    }
}