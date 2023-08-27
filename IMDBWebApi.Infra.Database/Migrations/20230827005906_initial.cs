using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMDBWebApi.Infra.Database.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHashSalt = table.Column<byte[]>(type: "varbinary(32)", maxLength: 32, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(12)", maxLength: 12, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Casts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommonUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHashSalt = table.Column<byte[]>(type: "varbinary(32)", maxLength: 32, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(12)", maxLength: 12, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Duration = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    TotalVotes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RatingAverage = table.Column<double>(type: "float(4)", precision: 4, scale: 2, nullable: false, defaultValue: 0.0),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CommonUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentRecords_CommonUsers_CommonUserId",
                        column: x => x.CommonUserId,
                        principalTable: "CommonUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentRecords_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CastActMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieActId = table.Column<int>(type: "int", nullable: false),
                    CastActId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastActMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastActMovies_Casts_CastActId",
                        column: x => x.CastActId,
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastActMovies_Movies_MovieActId",
                        column: x => x.MovieActId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CastDirectMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieDirectId = table.Column<int>(type: "int", nullable: false),
                    CastDirectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastDirectMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastDirectMovies_Casts_CastDirectorId",
                        column: x => x.CastDirectorId,
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastDirectMovies_Movies_MovieDirectId",
                        column: x => x.MovieDirectId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreMovies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_Email",
                table: "Administrators",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserName",
                table: "Administrators",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRecords_CommonUserId",
                table: "AssessmentRecords",
                column: "CommonUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRecords_MovieId",
                table: "AssessmentRecords",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CastActMovies_CastActId",
                table: "CastActMovies",
                column: "CastActId");

            migrationBuilder.CreateIndex(
                name: "IX_CastActMovies_MovieActId",
                table: "CastActMovies",
                column: "MovieActId");

            migrationBuilder.CreateIndex(
                name: "IX_CastDirectMovies_CastDirectorId",
                table: "CastDirectMovies",
                column: "CastDirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CastDirectMovies_MovieDirectId",
                table: "CastDirectMovies",
                column: "MovieDirectId");

            migrationBuilder.CreateIndex(
                name: "IX_Casts_Name",
                table: "Casts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommonUsers_Email",
                table: "CommonUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommonUsers_UserName",
                table: "CommonUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovies_GenreId",
                table: "GenreMovies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovies_MovieId",
                table: "GenreMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Name",
                table: "Movies",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "AssessmentRecords");

            migrationBuilder.DropTable(
                name: "CastActMovies");

            migrationBuilder.DropTable(
                name: "CastDirectMovies");

            migrationBuilder.DropTable(
                name: "GenreMovies");

            migrationBuilder.DropTable(
                name: "CommonUsers");

            migrationBuilder.DropTable(
                name: "Casts");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
