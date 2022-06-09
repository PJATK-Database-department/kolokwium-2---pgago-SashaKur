namespace TrackManager.DTO
{
    public class GetAlbum
    {
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public string MusicLabel { get; set; }
        public IEnumerable<TrackDTO> Tracks { get; set; }
    }
}
