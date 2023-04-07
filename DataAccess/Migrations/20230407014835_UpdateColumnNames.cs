using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmPersonLink_FilmRole_RoleId",
                table: "FilmPersonLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmPersonLink",
                table: "FilmPersonLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmGenreLink",
                table: "FilmGenreLink");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "FilmPersonLink",
                newName: "FilmRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmPersonLink_RoleId",
                table: "FilmPersonLink",
                newName: "IX_FilmPersonLink_FilmRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmPersonLink",
                table: "FilmPersonLink",
                columns: new[] { "FilmId", "PersonId", "FilmRoleId" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmGenreLink",
                table: "FilmGenreLink",
                columns: new[] { "FilmId", "GenreId" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmPersonLink_FilmRole_FilmRoleId",
                table: "FilmPersonLink",
                column: "FilmRoleId",
                principalTable: "FilmRole",
                principalColumn: "FilmRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmPersonLink_FilmRole_FilmRoleId",
                table: "FilmPersonLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmPersonLink",
                table: "FilmPersonLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmGenreLink",
                table: "FilmGenreLink");

            migrationBuilder.RenameColumn(
                name: "FilmRoleId",
                table: "FilmPersonLink",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmPersonLink_FilmRoleId",
                table: "FilmPersonLink",
                newName: "IX_FilmPersonLink_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmPersonLink",
                table: "FilmPersonLink",
                columns: new[] { "FilmId", "PersonId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmGenreLink",
                table: "FilmGenreLink",
                columns: new[] { "FilmId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FilmPersonLink_FilmRole_RoleId",
                table: "FilmPersonLink",
                column: "RoleId",
                principalTable: "FilmRole",
                principalColumn: "FilmRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
