using Microsoft.EntityFrameworkCore;
using System.Linq;
using TrackManager.Models;

namespace TrackManager.DataAccess
{
    public class ManagerContext : DbContext
    {
        public ManagerContext() { 
        }

        public ManagerContext(DbContextOptions options)
        : base(options)
        { 
        }

        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<MusicLabel> MusicLabels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if(!builder.IsConfigured)
            {
                builder.UseSqlServer("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");
            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.IdTrack)
                    .HasName("Track_pk");

                entity.ToTable("Track");

                entity.Property(e => e.TrackName).IsRequired().HasMaxLength(20);

                entity.Property(e => e.Duration).IsRequired();

                entity.Property(e => e.IdMusicAlbum).IsRequired();

                entity.HasData(
                    new Track { IdTrack = 1, IdMusicAlbum = 1, TrackName = "Track1", Duration = 2.64f },
                    new Track { IdTrack = 2, IdMusicAlbum = 1, TrackName = "Track2", Duration = 3f }
                    );
            });


            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.IdAlbum)
                    .HasName("Album_pk");

                entity.ToTable("Album");

                entity.Property(e => e.IdAlbum).ValueGeneratedNever();

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PublishDate)
                    .IsRequired().HasColumnType("datetime");

                entity.Property(e => e.IdMusicLabel)
                    .IsRequired();

                entity.HasData(
                    new Album { IdAlbum = 1, AlbumName = "Test1", PublishDate = new DateTime(2008, 5, 1, 8, 30, 52), IdMusicLabel = 1},
                    new Album { IdAlbum = 2, AlbumName = "Test2", PublishDate = new DateTime(2010, 5, 1, 8, 30, 52), IdMusicLabel = 2}
                    );

            });
            
            modelBuilder.Entity<Musician>(entity =>
            {
                entity.HasKey(e => e.IdMusician)
                   .HasName("Musician_pk");

                entity.ToTable("Musician");

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Nickname).IsRequired(false).HasMaxLength(20);

            });
            modelBuilder.Entity<MusicLabel>(entity =>
            {
                entity.HasKey(e => e.IdMusicLabel)
                    .HasName("MusicLabel_pk");

                entity.ToTable("MusicLabel");

                entity.Property(e=>e.Name).IsRequired().HasMaxLength(50);

                entity.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "Rock" },
                    new MusicLabel { IdMusicLabel = 2, Name = "Jazz"}
                    );
            });
        }

    }
}
