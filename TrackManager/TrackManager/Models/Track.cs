namespace TrackManager.Models
{
    public class Track
    {
        public Track()
        {
            Musicians = new HashSet<Musician>();
        }

        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public virtual ICollection<Musician> Musicians { get; set; }
        public int IdMusicAlbum { get; set; }
    }
}
