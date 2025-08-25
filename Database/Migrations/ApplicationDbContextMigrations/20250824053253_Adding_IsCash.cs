using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMJRegisterAPIV2.Database.Migrations.ApplicationDbContextMigrations
{
    /// <inheritdoc />
    public partial class Adding_IsCash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BanksInformationId",
                table: "Pagos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsCash",
                table: "Pagos",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCash",
                table: "Pagos");

            migrationBuilder.AlterColumn<int>(
                name: "BanksInformationId",
                table: "Pagos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
