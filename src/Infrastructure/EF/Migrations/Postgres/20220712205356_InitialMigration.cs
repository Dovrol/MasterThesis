using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.EF.Migrations.Postgres
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FIRST_NAME = table.Column<string>(type: "text", nullable: false),
                    LAST_NAME = table.Column<string>(type: "text", nullable: false),
                    EMAIL = table.Column<string>(type: "text", nullable: false),
                    GENDER = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERY_METHODS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERY_METHODS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENT_METHODS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT_METHODS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    ORDER_NUMBER = table.Column<Guid>(type: "uuid", nullable: false),
                    PAYMENT_METHOD = table.Column<int>(type: "integer", nullable: false),
                    DELIVERY_METHOD = table.Column<int>(type: "integer", nullable: false),
                    FREE_DELIVERY = table.Column<bool>(type: "boolean", nullable: false),
                    GROSS_VALUE = table.Column<decimal>(type: "numeric", nullable: false),
                    NET_VALUE = table.Column<decimal>(type: "numeric", nullable: false),
                    TAX_VALUE = table.Column<decimal>(type: "numeric", nullable: false),
                    TAX = table.Column<decimal>(type: "numeric", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FULLFILLMENT_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ORDER_NUMBER);
                    table.ForeignKey(
                        name: "FK_ORDERS_CUSTOMERS_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_DELIVERY_METHODS_DELIVERY_METHOD",
                        column: x => x.DELIVERY_METHOD,
                        principalTable: "DELIVERY_METHODS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_PAYMENT_METHODS_PAYMENT_METHOD",
                        column: x => x.PAYMENT_METHOD,
                        principalTable: "PAYMENT_METHODS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEMS",
                columns: table => new
                {
                    POSITION = table.Column<int>(type: "integer", nullable: false),
                    ORDER_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NAME = table.Column<string>(type: "text", nullable: false),
                    NET_VALUE = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEMS", x => new { x.ORDER_ID, x.POSITION });
                    table.ForeignKey(
                        name: "FK_ORDER_ITEMS_ORDERS_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDERS",
                        principalColumn: "ORDER_NUMBER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_CustomerId",
                table: "ORDERS",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_DELIVERY_METHOD",
                table: "ORDERS",
                column: "DELIVERY_METHOD");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_PAYMENT_METHOD",
                table: "ORDERS",
                column: "PAYMENT_METHOD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDER_ITEMS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "DELIVERY_METHODS");

            migrationBuilder.DropTable(
                name: "PAYMENT_METHODS");
        }
    }
}
