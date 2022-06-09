using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackManager.Migrations
{
    public partial class AlbumData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "MusicLabelIdMusicLabel", "PublishDate" },
                values: new object[,]
                {
                    { 1, "Test1", 1, null, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 2, "Test2", 2, null, new DateTime(2010, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MusicLabel",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Jazz" }
                });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "AlbumIdAlbum", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[,]
                {
                    { 1, null, 2.64f, 1, "Track1" },
                    { 2, null, 3f, 1, "Track2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MusicLabel",
                keyColumn: "IdMusicLabel",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MusicLabel",
                keyColumn: "IdMusicLabel",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 2);
        }
    }
}
