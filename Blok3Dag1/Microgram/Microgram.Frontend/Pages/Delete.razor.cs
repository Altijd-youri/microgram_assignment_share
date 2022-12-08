using Microgram.Shared.Core.Entities;
using Microgram.Shared.Core.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Microgram.Frontend.Pages;

public partial class Delete
{
    [Inject]
    private IPhotoRepository _photoRepository { get; set; }
    
    [Parameter]
    public string Id { get; set; }

    private Photo _photo = new();

    protected override async Task OnInitializedAsync()
    {
        int id;
        if (Int32.TryParse(Id, out id))
        {
            _photo = await _photoRepository.FindById(id);
        }
        else
        {
            throw new ArgumentException("Photo not found.");
        }
    }

    private async Task Submit(EditContext context)
    {
        StateHasChanged();
        await _photoRepository.DeletePhoto(_photo);
    }
}