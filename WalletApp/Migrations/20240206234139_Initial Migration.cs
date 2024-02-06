using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WalletApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardBalance = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionListId = table.Column<int>(type: "integer", nullable: false),
                    TransactionInitializerUserId = table.Column<int>(type: "integer", nullable: false),
                    TransactionInitializerUserName = table.Column<string>(type: "varchar(50)", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TransactionName = table.Column<string>(type: "varchar(50)", nullable: false),
                    TransactionType = table.Column<short>(type: "smallint", nullable: false),
                    TransactionFee = table.Column<decimal>(type: "money", nullable: false),
                    Pending = table.Column<bool>(type: "boolean", nullable: false),
                    TransactionDescription = table.Column<string>(type: "varchar(200)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_TransactionLists_TransactionListId",
                        column: x => x.TransactionListId,
                        principalTable: "TransactionLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_TransactionListId",
                table: "TransactionDetails",
                column: "TransactionListId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_UserId",
                table: "TransactionDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLists_UserId",
                table: "TransactionLists",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionDetails");

            migrationBuilder.DropTable(
                name: "TransactionLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
