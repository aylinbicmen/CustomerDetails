using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerDetails.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                schema: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    TaxNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddressTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalSchema: "Customer",
                        principalTable: "AddressTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "AddressTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Bireysel" },
                    { 2, "Kurumsal" }
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "Customers",
                columns: new[] { "Id", "Address", "AddressTypeId", "BirthDate", "Email", "IdentityNo", "IsActive", "Name", "Phone", "Surname", "TaxNo", "TaxOffice" },
                values: new object[,]
                {
                    { 3, null, null, new DateTime(1996, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "tuna_yildirim@outlook.com", null, true, "Tuna", "5305759862", "Yıldırım", null, null },
                    { 1, "Yedi Eylül Mah. Efeler/Aydın", 1, new DateTime(1985, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "ece.akyurek@gmail.com", "18015526289", true, "Ece", "5322262496", "Akyürek", null, null },
                    { 2, "Kazım Özalp Sok. Kadıköy/İstanbul", 2, new DateTime(1972, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "atakan-ozansoy@gmail.com", null, true, "Atakan", "5333441212", "Ozansoy", "5421977337", "Kadıköy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressTypeId",
                schema: "Customer",
                table: "Customers",
                column: "AddressTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Customer");

            migrationBuilder.DropTable(
                name: "AddressTypes",
                schema: "Customer");
        }
    }
}
