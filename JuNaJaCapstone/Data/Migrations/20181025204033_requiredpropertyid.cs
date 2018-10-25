using Microsoft.EntityFrameworkCore.Migrations;

namespace JuNaJaCapstone.Data.Migrations
{
    public partial class requiredpropertyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_Property_PropertyId",
                table: "PropertyImage");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyNote_Property_PropertyId",
                table: "PropertyNote");

            migrationBuilder.DropIndex(
                name: "IX_PropertyNote_PropertyId",
                table: "PropertyNote");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "PropertyNote",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "PropertyImage",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyNote_PropertyId",
                table: "PropertyNote",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_Property_PropertyId",
                table: "PropertyImage",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyNote_Property_PropertyId",
                table: "PropertyNote",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_Property_PropertyId",
                table: "PropertyImage");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyNote_Property_PropertyId",
                table: "PropertyNote");

            migrationBuilder.DropIndex(
                name: "IX_PropertyNote_PropertyId",
                table: "PropertyNote");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "PropertyNote",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "PropertyImage",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_Property_PropertyId",
                table: "PropertyImage",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyNote_Property_PropertyId",
                table: "PropertyNote",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
