using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SchemaInstantiation : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new {
                    FilmId = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    FilmTitle = table.Column<string>( type: "nvarchar(450)", nullable: false ),
                    ReleaseDate = table.Column<DateTime>( type: "datetime2", nullable: false )
                },
                constraints: table => {
                    table.PrimaryKey( "PK_Film", x => x.FilmId );
                } );

            migrationBuilder.CreateTable(
                name: "FilmRole",
                columns: table => new {
                    RoleId = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    FilmRoleTitle = table.Column<string>( type: "nvarchar(450)", nullable: false )
                },
                constraints: table => {
                    table.PrimaryKey( "PK_FilmRole", x => x.RoleId );
                } );

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new {
                    GenreId = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    GenreName = table.Column<string>( type: "nvarchar(450)", nullable: false )
                },
                constraints: table => {
                    table.PrimaryKey( "PK_Genre", x => x.GenreId );
                } );

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new {
                    PersonId = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    PersonName = table.Column<string>( type: "nvarchar(max)", nullable: false )
                },
                constraints: table => {
                    table.PrimaryKey( "PK_Person", x => x.PersonId );
                } );

            migrationBuilder.CreateTable(
                name: "FilmGenreLink",
                columns: table => new {
                    FilmId = table.Column<int>( type: "int", nullable: false ),
                    GenreId = table.Column<int>( type: "int", nullable: false )
                },
                constraints: table => {
                    table.PrimaryKey( "PK_FilmGenreLink", x => new { x.FilmId, x.GenreId } );
                    table.ForeignKey(
                        name: "FK_FilmGenreLink_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_FilmGenreLink_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "FilmPersonLink",
                columns: table => new {
                    FilmId = table.Column<int>( type: "int", nullable: false ),
                    PersonId = table.Column<int>( type: "int", nullable: false ),
                    RoleId = table.Column<int>( type: "int", nullable: false )
                },
                constraints: table => {
                    table.PrimaryKey( "PK_FilmPersonLink", x => new { x.FilmId, x.PersonId, x.RoleId } );
                    table.ForeignKey(
                        name: "FK_FilmPersonLink_FilmRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "FilmRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_FilmPersonLink_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_FilmPersonLink_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateIndex(
                name: "UQ_Film_TitleReleaseDate",
                table: "Film",
                columns: new[] { "FilmTitle", "ReleaseDate" },
                unique: true );

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenreLink_GenreId",
                table: "FilmGenreLink",
                column: "GenreId" );

            migrationBuilder.CreateIndex(
                name: "IX_FilmPersonLink_PersonId",
                table: "FilmPersonLink",
                column: "PersonId" );

            migrationBuilder.CreateIndex(
                name: "IX_FilmPersonLink_RoleId",
                table: "FilmPersonLink",
                column: "RoleId" );

            migrationBuilder.CreateIndex(
                name: "UQ_FilmRole_FilmRoleTitle",
                table: "FilmRole",
                column: "FilmRoleTitle",
                unique: true );

            migrationBuilder.CreateIndex(
                name: "UQ_Genre_GenreName",
                table: "Genre",
                column: "GenreName",
                unique: true );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "FilmGenreLink" );

            migrationBuilder.DropTable(
                name: "FilmPersonLink" );

            migrationBuilder.DropTable(
                name: "Genre" );

            migrationBuilder.DropTable(
                name: "FilmRole" );

            migrationBuilder.DropTable(
                name: "Film" );

            migrationBuilder.DropTable(
                name: "Person" );
        }
    }
}
