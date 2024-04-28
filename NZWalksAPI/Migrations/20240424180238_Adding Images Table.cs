using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("114e9d20-aaf7-4e17-bc15-9bc397e313ea"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("65917c9d-5f94-4afb-a70b-eeaf044d441e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a41826ce-e045-419f-be8c-663f86c4b01a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("13925abe-195b-4cff-b828-d3b028448eaa"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("47138c12-e811-435c-9872-b66a6e3bd84e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8d9b86c8-29b5-4a09-bb60-55bcc78b00ca"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e6337458-d771-4798-a965-a11e5c115dbb"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Difficulties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Difficulties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("114e9d20-aaf7-4e17-bc15-9bc397e313ea"), "Medium" },
                    { new Guid("65917c9d-5f94-4afb-a70b-eeaf044d441e"), "Easy" },
                    { new Guid("a41826ce-e045-419f-be8c-663f86c4b01a"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("13925abe-195b-4cff-b828-d3b028448eaa"), "BOM", "Mumbai", "mumbai.jpg" },
                    { new Guid("47138c12-e811-435c-9872-b66a6e3bd84e"), "DEL", "New Delhi", "delhi.jpg" },
                    { new Guid("8d9b86c8-29b5-4a09-bb60-55bcc78b00ca"), "PUN", "Pune", "pune.jpg" },
                    { new Guid("e6337458-d771-4798-a965-a11e5c115dbb"), "BNG", "Banglore", "banglore.jpg" }
                });
        }
    }
}
