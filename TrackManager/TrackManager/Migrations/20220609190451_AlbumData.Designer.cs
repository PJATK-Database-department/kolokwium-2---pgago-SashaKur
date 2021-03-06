// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackManager.DataAccess;

#nullable disable

namespace TrackManager.Migrations
{
    [DbContext(typeof(ManagerContext))]
    [Migration("20220609190451_AlbumData")]
    partial class AlbumData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Polish_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusicianTrack", b =>
                {
                    b.Property<int>("MusiciansIdMusician")
                        .HasColumnType("int");

                    b.Property<int>("TracksIdTrack")
                        .HasColumnType("int");

                    b.HasKey("MusiciansIdMusician", "TracksIdTrack");

                    b.HasIndex("TracksIdTrack");

                    b.ToTable("MusicianTrack");
                });

            modelBuilder.Entity("TrackManager.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .HasColumnType("int");

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<int?>("MusicLabelIdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime");

                    b.HasKey("IdAlbum")
                        .HasName("Album_pk");

                    b.HasIndex("MusicLabelIdMusicLabel");

                    b.ToTable("Album", (string)null);

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Test1",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "Test2",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2010, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TrackManager.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMusician"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician")
                        .HasName("Musician_pk");

                    b.ToTable("Musician", (string)null);
                });

            modelBuilder.Entity("TrackManager.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMusicLabel"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel")
                        .HasName("MusicLabel_pk");

                    b.ToTable("MusicLabel", (string)null);

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "Rock"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "Jazz"
                        });
                });

            modelBuilder.Entity("TrackManager.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTrack"), 1L, 1);

                    b.Property<int?>("AlbumIdAlbum")
                        .HasColumnType("int");

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack")
                        .HasName("Track_pk");

                    b.HasIndex("AlbumIdAlbum");

                    b.ToTable("Track", (string)null);

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 2.64f,
                            IdMusicAlbum = 1,
                            TrackName = "Track1"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 3f,
                            IdMusicAlbum = 1,
                            TrackName = "Track2"
                        });
                });

            modelBuilder.Entity("MusicianTrack", b =>
                {
                    b.HasOne("TrackManager.Models.Musician", null)
                        .WithMany()
                        .HasForeignKey("MusiciansIdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrackManager.Models.Track", null)
                        .WithMany()
                        .HasForeignKey("TracksIdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrackManager.Models.Album", b =>
                {
                    b.HasOne("TrackManager.Models.MusicLabel", null)
                        .WithMany("Albums")
                        .HasForeignKey("MusicLabelIdMusicLabel");
                });

            modelBuilder.Entity("TrackManager.Models.Track", b =>
                {
                    b.HasOne("TrackManager.Models.Album", null)
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumIdAlbum");
                });

            modelBuilder.Entity("TrackManager.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("TrackManager.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
