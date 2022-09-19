using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTickets.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ACTORS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ACTORS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_CINEMAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CINEMAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRODUCERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRODUCERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MOVIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieCategory = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MOVIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBL_MOVIES_TBL_CINEMAS_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "TBL_CINEMAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_MOVIES_TBL_PRODUCERS_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "TBL_PRODUCERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ACTORS_MOVIES",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    ActorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ACTORS_MOVIES", x => new { x.ActorID, x.MovieID });
                    table.ForeignKey(
                        name: "FK_TBL_ACTORS_MOVIES_TBL_ACTORS_ActorID",
                        column: x => x.ActorID,
                        principalTable: "TBL_ACTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_ACTORS_MOVIES_TBL_MOVIES_MovieID",
                        column: x => x.MovieID,
                        principalTable: "TBL_MOVIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ACTORS_MOVIES_MovieID",
                table: "TBL_ACTORS_MOVIES",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MOVIES_CinemaId",
                table: "TBL_MOVIES",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MOVIES_ProducerId",
                table: "TBL_MOVIES",
                column: "ProducerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ACTORS_MOVIES");

            migrationBuilder.DropTable(
                name: "TBL_ACTORS");

            migrationBuilder.DropTable(
                name: "TBL_MOVIES");

            migrationBuilder.DropTable(
                name: "TBL_CINEMAS");

            migrationBuilder.DropTable(
                name: "TBL_PRODUCERS");
        }
    }
}
