using System.Linq;
using TrackManager.DataAccess;
using TrackManager.DTO;
using TrackManager.Models;
using TrackManager.Repositories.Interfaces;

namespace TrackManager.Repositories.Implementations
{
    public class AlbumRep : IAlbumRep
    {
        private readonly ManagerContext context;

        public AlbumRep(ManagerContext context) { 
            this.context = context;
        }

        public async Task<IEnumerable<GetAlbum>> GetAlbumAsync(int IdAlbum)
        {
            string musicLabel = context.MusicLabels.Where(c => c.IdMusicLabel==IdAlbum).Select(c => c.Name).First();
            var albums = context.Albums.Select(row => new GetAlbum
            {
                AlbumName = row.AlbumName,
                PublishDate = row.PublishDate,
                Tracks = row.Tracks.Select(row => new TrackDTO { TrackName = row.TrackName, Duration = row.Duration }),
                MusicLabel = musicLabel
            }).OrderByDescending(col => col.PublishDate);


            if (!albums.Any()) throw new Exception("There is no data");

            return albums;
        }
    }
}