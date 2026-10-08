using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileMoneyAggregator.Migrations
{
    /// <inheritdoc />
    public partial class RenamPaymentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayementStatus",
                table: "Transactions",
                newName: "PaymentStatus");

            migrationBuilder.AlterColumn<decimal>(
                name: "Montant",
                table: "Transactions",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "Transactions",
                newName: "PayementStatus");

            migrationBuilder.AlterColumn<double>(
                name: "Montant",
                table: "Transactions",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
