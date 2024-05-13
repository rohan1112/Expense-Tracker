using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTB",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTB", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BudgetsTB",
                columns: table => new
                {
                    BudgetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetsTB", x => x.BudgetID);
                    table.ForeignKey(
                        name: "FK_BudgetsTB_UserTB_UserID",
                        column: x => x.UserID,
                        principalTable: "UserTB",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTB",
                columns: table => new
                {
                    ExpenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTB", x => x.ExpenseID);
                    table.ForeignKey(
                        name: "FK_ExpenseTB_UserTB_UserID",
                        column: x => x.UserID,
                        principalTable: "UserTB",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_ExpenseTB_UserTB_UserID1",
                        column: x => x.UserID1,
                        principalTable: "UserTB",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "TransactionTB",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ExpenseID = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OldAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NewAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTB", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_TransactionTB_ExpenseTB_ExpenseID",
                        column: x => x.ExpenseID,
                        principalTable: "ExpenseTB",
                        principalColumn: "ExpenseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionTB_UserTB_UserID",
                        column: x => x.UserID,
                        principalTable: "UserTB",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_TransactionTB_UserTB_UserID1",
                        column: x => x.UserID1,
                        principalTable: "UserTB",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetsTB_UserID",
                table: "BudgetsTB",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTB_UserID",
                table: "ExpenseTB",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTB_UserID1",
                table: "ExpenseTB",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTB_ExpenseID",
                table: "TransactionTB",
                column: "ExpenseID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTB_UserID",
                table: "TransactionTB",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTB_UserID1",
                table: "TransactionTB",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_UserTB_Email",
                table: "UserTB",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetsTB");

            migrationBuilder.DropTable(
                name: "TransactionTB");

            migrationBuilder.DropTable(
                name: "ExpenseTB");

            migrationBuilder.DropTable(
                name: "UserTB");
        }
    }
}
