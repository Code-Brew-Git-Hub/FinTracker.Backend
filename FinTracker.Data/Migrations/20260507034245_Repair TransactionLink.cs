using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class RepairTransactionLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLinkEntries_Transactions_TransactionId1",
                table: "TransactionLinkEntries");

            migrationBuilder.DropIndex(
                name: "IX_TransactionLinkEntries_TransactionId1",
                table: "TransactionLinkEntries");

            migrationBuilder.DropColumn(
                name: "TransactionId1",
                table: "TransactionLinkEntries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId1",
                table: "TransactionLinkEntries",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLinkEntries_TransactionId1",
                table: "TransactionLinkEntries",
                column: "TransactionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLinkEntries_Transactions_TransactionId1",
                table: "TransactionLinkEntries",
                column: "TransactionId1",
                principalTable: "Transactions",
                principalColumn: "Id");
        }
    }
}
