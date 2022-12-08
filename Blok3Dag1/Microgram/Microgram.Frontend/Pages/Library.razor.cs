using Microgram.Shared.Core.Entities;
using Microgram.Shared.Core.Repository;
using Microsoft.AspNetCore.Components;

namespace Microgram.Frontend.Pages;

public partial class Library
{
    public int GridSpacing { get; set; } = 2;
    
    
    [Inject]
    private IPhotoRepository PhotoRepository { get; set; }

    private List<Photo> _photos = new ();

    protected override async Task OnInitializedAsync()
    {
        _photos = await PhotoRepository.GetPhotoList();
    }
}