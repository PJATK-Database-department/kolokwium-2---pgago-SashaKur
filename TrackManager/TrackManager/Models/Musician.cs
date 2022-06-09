namespace TrackManager.Models
{
    public class Musician
    {
        public Musician() {
            Tracks = new HashSet<Track>();
        }
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }

    }
}
