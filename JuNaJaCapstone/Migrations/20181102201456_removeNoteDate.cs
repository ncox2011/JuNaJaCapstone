using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuNaJaCapstone.Migrations
{
    public partial class removeNoteDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateNoted",
                table: "PropertyNote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateNoted",
                table: "PropertyNote",
                nullable: true);
        }
    }
}
