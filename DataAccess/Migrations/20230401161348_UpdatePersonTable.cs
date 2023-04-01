using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Person",
                nullable: false,
                maxLength: 60
            );

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Person",
                nullable: false,
                maxLength: 60
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Person",
                nullable: false
            );
            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Person"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Person" 
            );
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Person" 
            );
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Person" 
            );
            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Person",
                nullable: false
            );
        }
    }
}
