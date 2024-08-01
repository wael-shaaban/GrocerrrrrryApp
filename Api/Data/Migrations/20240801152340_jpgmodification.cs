using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class jpgmodification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)11,
                column: "Image",
                value: "eggs_meat.jpg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)12,
                column: "Image",
                value: "eggs.jpg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)13,
                column: "Image",
                value: "meat.jpg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)14,
                column: "Image",
                value: "seafood.jpg");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "#7fbdc7");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Color",
                value: "#ffff00");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Color",
                value: "#ea978d");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Color",
                value: "#dad1f9");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)11,
                column: "Image",
                value: "eggs_meat.png");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)12,
                column: "Image",
                value: "eggs.png");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)13,
                column: "Image",
                value: "meat.png");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)14,
                column: "Image",
                value: "seafood.png");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "#e1f1e7");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Color",
                value: "#d0f200");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Color",
                value: "#7fbdc7");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Color",
                value: "#ffff00");
        }
    }
}
