using Microgram.Backend.Core.Enitities;
using Microgram.Backend.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Microgram.Backend.Controllers;

[ApiController]
public class PhotoController : ControllerBase
{
    private IPhotoRepository _photoRepository;
    
    public PhotoController(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }
    
    [HttpGet("/api/photo")]
    public async Task<ActionResult<IEnumerable<PhotoEntity>>> GetPhotoList()
    {
        return Ok(await _photoRepository.GetPhotoList());
    }
    
    [HttpGet("/api/photo/{id}")]
    public async Task<ActionResult<PhotoEntity>> GetPhotoById([FromRoute] string id)
    {
        if (Int32.TryParse(id, out var parsedId))
        {
            try
            {
                return Ok(await _photoRepository.FindById(parsedId));
            }
            catch (ArgumentException e)
            {
                return NotFound();
            }
        }
        return BadRequest();
        
    }
    
    [HttpDelete("/api/photo/{id}")]
    public async Task<ActionResult> DeletePhotoById([FromRoute] string id)
    {
        int parsedId;
        if (Int32.TryParse(id, out parsedId))
        {
            PhotoEntity photoToDelete;
            try
            {
                photoToDelete = await _photoRepository.FindById(parsedId);
            }
            catch (ArgumentException e)
            {
                return Ok();
            }
            await _photoRepository.DeletePhoto(photoToDelete);
            return Ok();
        }
        return BadRequest();
        
    }
    
    [HttpPatch("/api/photo")]
    public async Task<ActionResult<PhotoEntity>> PatchPhoto([FromBody] PhotoEntity photo)
    {
        if (ModelState.IsValid)
        {
            try
            {
                PhotoEntity changedPhoto = await _photoRepository.UpdatePhoto(photo);
                return Ok(changedPhoto);
            }
            catch (ArgumentException e)
            {
                return NotFound();
            }

        }
        return BadRequest();
    }
    
    [HttpPost("/api/photo")]
    public async Task<ActionResult<PhotoEntity>> PostPhoto([FromBody] PhotoEntity photo)
    {
        if (ModelState.IsValid)
        {
            PhotoEntity newPhoto = await _photoRepository.AddPhoto(photo);
            var url = $"/api/photo/{newPhoto.Id}";
            return Created(url, newPhoto);
        }
        return BadRequest();
    }
}