using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
