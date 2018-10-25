using Microsoft.EntityFrameworkCore.Migrations;

namespace JuNaJaCapstone.Data.Migrations
{
    public partial class noteandimgnotvirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PropertyNote_PropertyId",
                table: "PropertyNote");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyNote_PropertyId",
                table: "PropertyNote",
                column: "PropertyId",
                unique: true,
                filter: "[PropertyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage",
                column: "PropertyId",
                unique: true,
                filter: "[PropertyId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PropertyNote_PropertyId",
                table: "PropertyNote");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyNote_PropertyId",
                table: "PropertyNote",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage",
                column: "PropertyId");
        }
    }
}
