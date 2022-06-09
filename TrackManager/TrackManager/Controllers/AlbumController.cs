using Microsoft.AspNetCore.Mvc;
using TrackManager.Repositories.Interfaces;

namespace TrackManager.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {

        private readonly IAlbumRep repository;

        public AlbumController(IAlbumRep rep) { 
            this.repository = rep;
        }

        [HttpGet("{idAlbum}")]
        public async Task<IActionResult> GetAlbumAsync([FromRoute] int idAlbum) {
            try
            {
                var albums = await repository.GetAlbumAsync(idAlbum);
                return Ok(albums);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
    }
}
