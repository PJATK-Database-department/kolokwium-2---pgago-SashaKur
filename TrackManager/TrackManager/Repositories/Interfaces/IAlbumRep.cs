using TrackManager.DTO;

namespace TrackManager.Repositories.Interfaces
{
    public interface IAlbumRep
    {
        Task<IEnumerable<GetAlbum>> GetAlbumAsync(int IdAlbum);
    }
}
