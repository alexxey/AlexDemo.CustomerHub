using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlexDemo.CustomerHub.DataAccess.EF.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "demo");

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "demo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HeadOfficeCountry = table.Column<byte>(type: "tinyint", nullable: false),
                    CeoName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AnnualRevenue = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    Currency = table.Column<byte>(type: "tinyint", nullable: false),
                    BusinessType = table.Column<byte>(type: "tinyint", nullable: false),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyOffice",
                schema: "demo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OfficeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<byte>(type: "tinyint", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: false),
                    IsHeadOffice = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOffice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyOffice_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "demo",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "demo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CompanyRole = table.Column<byte>(type: "tinyint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryOfficeId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_CompanyOffice_PrimaryOfficeId",
                        column: x => x.PrimaryOfficeId,
                        principalSchema: "demo",
                        principalTable: "CompanyOffice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "demo",
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "demo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ProjectBudget = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    ProjectStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    ResponsibleOfficeId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ProjectOwnerId = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_CompanyOffice_ResponsibleOfficeId",
                        column: x => x.ResponsibleOfficeId,
                        principalSchema: "demo",
                        principalTable: "CompanyOffice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "demo",
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_User_ProjectOwnerId",
                        column: x => x.ProjectOwnerId,
                        principalSchema: "demo",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                schema: "demo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    CurrentRole = table.Column<byte>(type: "tinyint", nullable: false),
                    PositionDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "demo",
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectUser_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "demo",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "demo",
                table: "Company",
                columns: new[] { "Id", "AnnualRevenue", "BrandName", "BusinessType", "CeoName", "Currency", "Email", "HeadOfficeCountry", "NumberOfEmployees", "Status", "UpdatedOn", "WebSite" },
                values: new object[,]
                {
                    { 1, 3700000m, "Bentley", (byte)3, "Adrian Hallmark", (byte)1, "bentley@demo.com", (byte)1, 5000, (byte)2, new DateTime(2024, 8, 28, 19, 3, 43, 420, DateTimeKind.Utc).AddTicks(1334), "www.bentleymotors.com" },
                    { 2, 1400000000m, "Aston Martin", (byte)3, "Amedeo Felisa", (byte)1, "aston-martin@demo.com", (byte)1, 2500, (byte)2, new DateTime(2024, 8, 28, 19, 4, 43, 420, DateTimeKind.Utc).AddTicks(1348), "www.astonmartin.com" },
                    { 3, 158000000000m, "BMW", (byte)6, "Oliver Zipse", (byte)3, "bnw@demo.com", (byte)3, 130000, (byte)1, new DateTime(2024, 8, 28, 19, 4, 43, 420, DateTimeKind.Utc).AddTicks(1353), null },
                    { 4, 36200000000m, "Volvo", (byte)4, "Jim Rowan", (byte)3, "volvo@demo.com", (byte)2, 40000, (byte)2, new DateTime(2024, 8, 22, 19, 4, 43, 420, DateTimeKind.Utc).AddTicks(1357), null },
                    { 5, 240000000000m, "Toyota", (byte)6, "Akio Toyoda", (byte)4, "toyota@demo.com", (byte)6, 370000, (byte)3, new DateTime(2024, 8, 28, 19, 4, 43, 420, DateTimeKind.Utc).AddTicks(1362), null },
                    { 6, 61400000000m, "Audi", (byte)5, "Markus Duesmann", (byte)3, "audi@demo.com", (byte)3, 90000, (byte)2, new DateTime(2024, 8, 28, 19, 4, 43, 420, DateTimeKind.Utc).AddTicks(1364), null },
                    { 7, 167000000000m, "Ford", (byte)6, "Jim Farley", (byte)2, "ford@demo.com", (byte)5, 180000, (byte)2, new DateTime(2024, 8, 28, 19, 4, 43, 420, DateTimeKind.Utc).AddTicks(1366), null },
                    { 8, 23000000000m, "Skoda", (byte)4, "Klaus Zellmer", (byte)3, "skoda@demo.com", (byte)4, 45000, (byte)1, new DateTime(2024, 8, 28, 19, 4, 43, 420, DateTimeKind.Utc).AddTicks(1368), null }
                });

            migrationBuilder.InsertData(
                schema: "demo",
                table: "CompanyOffice",
                columns: new[] { "Id", "CompanyId", "Country", "IsHeadOffice", "Name", "NumberOfEmployees", "OfficeCode", "Status", "UpdatedOn", "ZipCode" },
                values: new object[,]
                {
                    { 1, 1, (byte)1, true, "Bentley Motors Crewe", 4000, "BNTL-1", (byte)0, new DateTime(2024, 8, 28, 19, 4, 43, 420, DateTimeKind.Utc).AddTicks(2421), "CW1 3PL" },
                    { 2, 2, (byte)1, true, "Aston Martin Gaydon", 100, "ASTN-1", (byte)0, new DateTime(2024, 8, 28, 19, 4, 43, 420, DateTimeKind.Utc).AddTicks(2423), "CV35 0DB" }
                });

            migrationBuilder.InsertData(
                schema: "demo",
                table: "User",
                columns: new[] { "Id", "CompanyId", "CompanyRole", "DateOfBirth", "Email", "FirstName", "LastName", "Login", "PasswordHash", "PasswordSalt", "PrimaryOfficeId", "Status", "Title", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, (byte)0, new DateTime(1981, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "test.bentley@bentley.com", "Test", "Sir", "test.bentley", "zovGOA3YWAS3zvq2u2ZOk1KIJjxouLbICvRWhaOruKE=", "MYl5TjrpFHEPQfwJ3VpaoQ==", 1, (byte)0, "Mr", new DateTime(2024, 8, 28, 19, 4, 43, 426, DateTimeKind.Utc).AddTicks(8312) },
                    { 2, 2, (byte)0, new DateTime(1983, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "test.aston@aston.com", "Test", "Madam", "test.aston", "ZbXlzKwPR37xs9Wg07PSrIWFF/cQHbYlYubwApCFJjc=", "6k3rIbC7f0Os16HWelRuKg==", 2, (byte)0, "Mrs", new DateTime(2024, 8, 28, 19, 4, 43, 428, DateTimeKind.Utc).AddTicks(6577) },
                    { 3, 1, (byte)0, new DateTime(1999, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user.bentley@aston.com", null, null, "user.benntley", "s6JoPoGMlg/Cts3MlJLe1nIPHTOqOrPjrYoIaiqCF+0=", "88ZY+gDfqCTvuA5tRWsTmQ==", 1, (byte)0, null, new DateTime(2024, 8, 28, 19, 4, 43, 430, DateTimeKind.Utc).AddTicks(4725) }
                });

            migrationBuilder.InsertData(
                schema: "demo",
                table: "Project",
                columns: new[] { "Id", "CompanyId", "Description", "EndDate", "Name", "ProjectBudget", "ProjectCode", "ProjectOwnerId", "ProjectStatus", "ResponsibleOfficeId", "StartDate", "Status", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, "test bentley project", null, "first bentley project", 0m, "BNTL-TEST", 1, (byte)0, 1, new DateTime(2024, 9, 4, 19, 4, 43, 430, DateTimeKind.Utc).AddTicks(5867), (byte)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, "second test bentley project", null, "second bentley project", 0m, "BNTL-TEST-2", 1, (byte)0, 1, new DateTime(2024, 8, 29, 19, 4, 43, 430, DateTimeKind.Utc).AddTicks(5876), (byte)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "demo",
                table: "ProjectUser",
                columns: new[] { "Id", "CurrentRole", "EndDate", "PositionDescription", "ProjectId", "StartDate", "Status", "UpdatedOn", "UserId" },
                values: new object[] { 1L, (byte)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2024, 8, 28, 19, 4, 43, 430, DateTimeKind.Utc).AddTicks(6630), (byte)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Company_BrandName",
                schema: "demo",
                table: "Company",
                column: "BrandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_Status",
                schema: "demo",
                table: "Company",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_UX_Company_Email",
                schema: "demo",
                table: "Company",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOffice_CompanyId",
                schema: "demo",
                table: "CompanyOffice",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UX_CO_Code",
                schema: "demo",
                table: "CompanyOffice",
                column: "OfficeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId",
                schema: "demo",
                table: "Project",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectOwnerId",
                schema: "demo",
                table: "Project",
                column: "ProjectOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ResponsibleOfficeId",
                schema: "demo",
                table: "Project",
                column: "ResponsibleOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_ProjectId",
                schema: "demo",
                table: "ProjectUser",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_UserId",
                schema: "demo",
                table: "ProjectUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                schema: "demo",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PrimaryOfficeId",
                schema: "demo",
                table: "User",
                column: "PrimaryOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_UX_User_Login",
                schema: "demo",
                table: "User",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUser",
                schema: "demo");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "demo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "demo");

            migrationBuilder.DropTable(
                name: "CompanyOffice",
                schema: "demo");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "demo");
        }
    }
}
