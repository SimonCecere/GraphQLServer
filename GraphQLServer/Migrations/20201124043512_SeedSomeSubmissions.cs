using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLServer.Migrations
{
    public partial class SeedSomeSubmissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Submission",
                columns: new[] { "Id", "Address1", "Address2", "City", "ClientSubmissionId", "CountryCode", "DateTime", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State", "Status" },
                values: new object[] { 1, "1175 S Pokegama Ave", null, "Grand Rapids", "4564123456789456", "USA", new DateTime(2020, 11, 23, 22, 35, 11, 966, DateTimeKind.Local).AddTicks(4118), "culvers@example.com", "John", "Doe", "6125555555", "55744", "MN", "PENDING" });

            migrationBuilder.InsertData(
                table: "Submission",
                columns: new[] { "Id", "Address1", "Address2", "City", "ClientSubmissionId", "CountryCode", "DateTime", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State", "Status" },
                values: new object[] { 2, "239 Vauxhall Bridge Rd", null, "London", "7893541231456654", "GBR", new DateTime(2020, 11, 23, 22, 35, 11, 968, DateTimeKind.Local).AddTicks(7449), "alan@example.com", "Alan", "Watts", "6125555555", "SO40 9RB", "", "PENDING" });

            migrationBuilder.InsertData(
                table: "Submission",
                columns: new[] { "Id", "Address1", "Address2", "City", "ClientSubmissionId", "CountryCode", "DateTime", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State", "Status" },
                values: new object[] { 3, "6000 Universal Blvd", null, "Orlando", "7893541231456654", "USA", new DateTime(2020, 11, 23, 22, 35, 11, 968, DateTimeKind.Local).AddTicks(7536), "harrypotter@hogwarts.com", "Harry", "Potter", "6125555555", "32819", "FL", "PENDING" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Submission",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Submission",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Submission",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
