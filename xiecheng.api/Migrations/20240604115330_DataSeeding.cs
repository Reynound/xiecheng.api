using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xiecheng.api.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("bcbdb440-5af5-471b-97a9-e1357bf8a91f"), new DateTime(2024, 6, 4, 19, 53, 30, 477, DateTimeKind.Local).AddTicks(8290), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "shuoming", 0.10000000000000001, "liangdian", "123", "jilu", 0m, "ceshi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("bcbdb440-5af5-471b-97a9-e1357bf8a91f"));
        }
    }
}
