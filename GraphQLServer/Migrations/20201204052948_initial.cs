using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLServer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MethodOfShipment = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    Buffer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientSubmissionId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    ShippedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOrder_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrder_Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Buffer", "Description", "Inventory", "MethodOfShipment", "SKU" },
                values: new object[,]
                {
                    { 1, 20, "Elder Wand", 1000, "UPS", "EW02112152" },
                    { 2, 10, "Philosophy 101", 200, "UPS", "PH02112101" },
                    { 3, 10, "Cookie Dough", 600, "UPS", "CD02112613" }
                });

            migrationBuilder.InsertData(
                table: "Submission",
                columns: new[] { "Id", "Address1", "Address2", "City", "ClientSubmissionId", "CountryCode", "DateTime", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State", "Status" },
                values: new object[,]
                {
                    { 1, "1175 S Pokegama Ave", null, "Grand Rapids", "4564123456789456", "USA", new DateTime(2020, 12, 3, 23, 29, 48, 321, DateTimeKind.Local).AddTicks(7943), "culvers@example.com", "John", "Doe", "6125555555", "55744", "MN", "PENDING" },
                    { 2, "239 Vauxhall Bridge Rd", null, "London", "7893541231456654", "GBR", new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(1857), "alan@example.com", "Alan", "Watts", "6125555555", "SO40 9RB", "", "PENDING" },
                    { 3, "6000 Universal Blvd", null, "Orlando", "7893541231456654", "USA", new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(1944), "AlbusD@hogwarts.com", "Albus", "Dumbledore", "6125555555", "32819", "FL", "PENDING" }
                });

            migrationBuilder.InsertData(
                table: "ItemOrder",
                columns: new[] { "Id", "ProductId", "QTY", "ShippedDateTime", "SubmissionId", "TrackingNumber" },
                values: new object[,]
                {
                    { 6, 3, 2, new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(4282), 1, "1Z204E380338945987" },
                    { 1, 2, 5, new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(3509), 2, "1Z204E380338943508" },
                    { 2, 1, 3, new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(4219), 2, "1Z204E380338943508" },
                    { 3, 3, 7, new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(4240), 2, "1Z204E380338943587" },
                    { 4, 2, 5, new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(4244), 3, "1Z204E380338945687" },
                    { 5, 1, 10, new DateTime(2020, 12, 3, 23, 29, 48, 324, DateTimeKind.Local).AddTicks(4278), 3, "1Z204E380338945687" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrder_ProductId",
                table: "ItemOrder",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrder_SubmissionId",
                table: "ItemOrder",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SKU",
                table: "Product",
                column: "SKU",
                unique: true,
                filter: "[SKU] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemOrder");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Submission");
        }
    }
}
