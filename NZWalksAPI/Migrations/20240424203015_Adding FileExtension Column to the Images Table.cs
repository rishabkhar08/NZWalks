using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingFileExtensionColumntotheImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4389db7f-e12b-411e-b605-21febbf5a3b5"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b24562aa-b0be-4b10-92f1-bad73fe39aa6"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f3edce08-41fb-4aad-94f9-c41601568887"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("74e979f1-ef52-427c-88f3-a29db2902e1d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7ece31b9-77e1-4590-9b95-ed883cff526a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("857c1dba-8c5f-4964-bcf1-5967709b8c81"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9b6355fb-9d68-47cf-b558-889a13e4d5ef"));

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a550caa-6aab-48a1-a790-d659ff11f012"), "Easy" },
                    { new Guid("aa9abb09-0754-4190-b37c-161f23a11d1d"), "Medium" },
                    { new Guid("ae5dbfa7-69e6-4c86-b5fb-245b0db6f38c"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3db627bc-d491-4c49-8c86-c1234d92ac80"), "BOM", "Mumbai", "mumbai.jpg" },
                    { new Guid("88c5aee6-ebc5-4422-9b5f-bb60a6a12c74"), "BNG", "Banglore", "banglore.jpg" },
                    { new Guid("dcf79b0c-0e6f-428a-85c9-6214304ac507"), "DEL", "New Delhi", "delhi.jpg" },
                    { new Guid("e4091faa-8223-4ef4-8752-b54c258039bc"), "PUN", "Pune", "pune.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2a550caa-6aab-48a1-a790-d659ff11f012"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("aa9abb09-0754-4190-b37c-161f23a11d1d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ae5dbfa7-69e6-4c86-b5fb-245b0db6f38c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3db627bc-d491-4c49-8c86-c1234d92ac80"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("88c5aee6-ebc5-4422-9b5f-bb60a6a12c74"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("dcf79b0c-0e6f-428a-85c9-6214304ac507"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e4091faa-8223-4ef4-8752-b54c258039bc"));

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Images");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4389db7f-e12b-411e-b605-21febbf5a3b5"), "Easy" },
                    { new Guid("b24562aa-b0be-4b10-92f1-bad73fe39aa6"), "Medium" },
                    { new Guid("f3edce08-41fb-4aad-94f9-c41601568887"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("74e979f1-ef52-427c-88f3-a29db2902e1d"), "PUN", "Pune", "pune.jpg" },
                    { new Guid("7ece31b9-77e1-4590-9b95-ed883cff526a"), "BOM", "Mumbai", "mumbai.jpg" },
                    { new Guid("857c1dba-8c5f-4964-bcf1-5967709b8c81"), "DEL", "New Delhi", "delhi.jpg" },
                    { new Guid("9b6355fb-9d68-47cf-b558-889a13e4d5ef"), "BNG", "Banglore", "banglore.jpg" }
                });
        }
    }
}
