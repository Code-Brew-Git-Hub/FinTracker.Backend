using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddValidationModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValidationRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValidationIssues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RuleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidationIssues_ValidationRules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "ValidationRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValidationIssueTransactions",
                columns: table => new
                {
                    ValidationIssueId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationIssueTransactions", x => new { x.ValidationIssueId, x.TransactionId });
                    table.ForeignKey(
                        name: "FK_ValidationIssueTransactions_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValidationIssueTransactions_ValidationIssues_ValidationIssu~",
                        column: x => x.ValidationIssueId,
                        principalTable: "ValidationIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ValidationRules",
                columns: new[] { "Id", "Description", "IsEnabled", "Name" },
                values: new object[] { new Guid("a0000001-0000-4000-8000-000000000001"), "Поиск транзакций с одинаковой датой, суммой, описанием и валютой", true, "Полностью идентичные транзакции" });

            migrationBuilder.CreateIndex(
                name: "IX_ValidationIssues_RuleId",
                table: "ValidationIssues",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationIssueTransactions_TransactionId",
                table: "ValidationIssueTransactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRules_Name",
                table: "ValidationRules",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValidationIssueTransactions");

            migrationBuilder.DropTable(
                name: "ValidationIssues");

            migrationBuilder.DropTable(
                name: "ValidationRules");
        }
    }
}
