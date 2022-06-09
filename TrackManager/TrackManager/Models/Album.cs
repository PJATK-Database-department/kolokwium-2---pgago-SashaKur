namespace TrackManager.Models
{
    public partial class Album
    {
        public Album() {
            Tracks = new HashSet<Track>();
        }
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }

        public DateTime PublishDate { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }

        public int IdMusicLabel { get; set; }

    }
}
