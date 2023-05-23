using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFilmRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.RenameColumn(
                name: "FilmRoleTitle",
                table: "FilmRole",
                newName: "FilmRoleName" );

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "FilmRole",
                newName: "FilmRoleId" );

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Person",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof( string ),
                oldType: "nvarchar(max)" );

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FilmRole",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "" );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FilmRole" );

            migrationBuilder.RenameColumn(
                name: "FilmRoleName",
                table: "FilmRole",
                newName: "FilmRoleTitle" );

            migrationBuilder.RenameColumn(
                name: "FilmRoleId",
                table: "FilmRole",
                newName: "RoleId" );

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof( string ),
                oldType: "nvarchar(60)",
                oldMaxLength: 60 );
        }
    }
}
