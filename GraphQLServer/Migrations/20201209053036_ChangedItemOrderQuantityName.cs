using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLServer.Migrations
{
    public partial class ChangedItemOrderQuantityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QTY",
                table: "ItemOrder",
                newName: "Quantity");

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 6,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 12, 8, 23, 30, 35, 674, DateTimeKind.Local).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2020, 12, 8, 23, 30, 35, 676, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2020, 12, 8, 23, 30, 35, 676, DateTimeKind.Local).AddTicks(8901));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ItemOrder",
                newName: "QTY");

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "ItemOrder",
                keyColumn: "Id",
                keyValue: 6,
                column: "ShippedDateTime",
                value: new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 12, 3, 23, 29, 48, 321, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(1944));
        }
    }
}
