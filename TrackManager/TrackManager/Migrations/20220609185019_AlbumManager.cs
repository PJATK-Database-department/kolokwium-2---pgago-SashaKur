using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackManager.Migrations
{
    public partial class AlbumManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musician",
                columns: table => new
                {
                    IdMusician = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Musician_pk", x => x.IdMusician);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabel",
                columns: table => new
                {
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MusicLabel_pk", x => x.IdMusicLabel);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false),
                    AlbumName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false),
                    MusicLabelIdMusicLabel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Album_pk", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Album_MusicLabel_MusicLabelIdMusicLabel",
                        column: x => x.MusicLabelIdMusicLabel,
                        principalTable: "MusicLabel",
                        principalColumn: "IdMusicLabel");
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    IdMusicAlbum = table.Column<int>(type: "int", nullable: false),
                    AlbumIdAlbum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Track_pk", x => x.IdTrack);
                    table.ForeignKey(
                        name: "FK_Track_Album_AlbumIdAlbum",
                        column: x => x.AlbumIdAlbum,
                        principalTable: "Album",
                        principalColumn: "IdAlbum");
                });

            migrationBuilder.CreateTable(
                name: "MusicianTrack",
                columns: table => new
                {
                    MusiciansIdMusician = table.Column<int>(type: "int", nullable: false),
                    TracksIdTrack = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianTrack", x => new { x.MusiciansIdMusician, x.TracksIdTrack });
                    table.ForeignKey(
                        name: "FK_MusicianTrack_Musician_MusiciansIdMusician",
                        column: x => x.MusiciansIdMusician,
                        principalTable: "Musician",
                        principalColumn: "IdMusician",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianTrack_Track_TracksIdTrack",
                        column: x => x.TracksIdTrack,
                        principalTable: "Track",
                        principalColumn: "IdTrack",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_MusicLabelIdMusicLabel",
                table: "Album",
                column: "MusicLabelIdMusicLabel");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianTrack_TracksIdTrack",
                table: "MusicianTrack",
                column: "TracksIdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Track_AlbumIdAlbum",
                table: "Track",
                column: "AlbumIdAlbum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicianTrack");

            migrationBuilder.DropTable(
                name: "Musician");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "MusicLabel");
        }
    }
}
