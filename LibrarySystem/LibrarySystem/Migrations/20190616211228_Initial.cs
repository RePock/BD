using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LibrarySystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    TypeOfEdition = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryFunds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryFunds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Limits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LimitValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NumberOfHall = table.Column<int>(nullable: false),
                    NumberOfShelving = table.Column<int>(nullable: false),
                    NumberOfBench = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    LibraryFundId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libraries_LibraryFunds_LibraryFundId",
                        column: x => x.LibraryFundId,
                        principalTable: "LibraryFunds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    EditionId = table.Column<int>(nullable: true),
                    TypeOfCategory = table.Column<byte>(nullable: false),
                    LocationId = table.Column<int>(nullable: true),
                    LimitId = table.Column<int>(nullable: true),
                    InStock = table.Column<bool>(nullable: false),
                    LibraryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Limits_LimitId",
                        column: x => x.LimitId,
                        principalTable: "Limits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    LibraryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readers_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ReadersId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    NumberOfPensionDocument = table.Column<int>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    Class = table.Column<int>(nullable: true),
                    Organization = table.Column<string>(nullable: true),
                    Theme = table.Column<string>(nullable: true),
                    Faculty = table.Column<string>(nullable: true),
                    Course = table.Column<int>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    Teacher_University = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    WorkPlace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Readers_ReadersId",
                        column: x => x.ReadersId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Readers_ReadersId1",
                        column: x => x.ReadersId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Readers_ReadersId2",
                        column: x => x.ReadersId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Readers_ReadersId3",
                        column: x => x.ReadersId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Readers_ReadersId4",
                        column: x => x.ReadersId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Readers_ReadersId5",
                        column: x => x.ReadersId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateOfIssue = table.Column<DateTime>(nullable: false),
                    DateOfExpiry = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    TicketId = table.Column<int>(nullable: true),
                    IsReturned = table.Column<bool>(nullable: false),
                    LibraryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issues_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibraryWorkers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LibraryId = table.Column<int>(nullable: false),
                    IssueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryWorkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryWorkers_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryWorkers_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_LibraryId",
                table: "Issues",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ProductId",
                table: "Issues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_TicketId",
                table: "Issues",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_LibraryFundId",
                table: "Libraries",
                column: "LibraryFundId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryWorkers_IssueId",
                table: "LibraryWorkers",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryWorkers_LibraryId",
                table: "LibraryWorkers",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AuthorId",
                table: "Products",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_EditionId",
                table: "Products",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LibraryId",
                table: "Products",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LimitId",
                table: "Products",
                column: "LimitId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LocationId",
                table: "Products",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_LibraryId",
                table: "Readers",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReadersId",
                table: "Tickets",
                column: "ReadersId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReadersId1",
                table: "Tickets",
                column: "ReadersId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReadersId2",
                table: "Tickets",
                column: "ReadersId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReadersId3",
                table: "Tickets",
                column: "ReadersId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReadersId4",
                table: "Tickets",
                column: "ReadersId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReadersId5",
                table: "Tickets",
                column: "ReadersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryWorkers");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Limits");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "LibraryFunds");
        }
    }
}
