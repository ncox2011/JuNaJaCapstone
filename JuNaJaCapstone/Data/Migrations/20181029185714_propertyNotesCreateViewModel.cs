using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuNaJaCapstone.Data.Migrations
{
    public partial class propertyNotesCreateViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateNoted",
                table: "PropertyNote",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateNoted",
                table: "PropertyNote",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
