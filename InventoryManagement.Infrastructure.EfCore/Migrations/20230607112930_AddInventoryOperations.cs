﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryOperations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryOperations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operation = table.Column<bool>(type: "bit", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    OperatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentCount = table.Column<long>(type: "bigint", nullable: false),
                    Describtion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    ProductvarientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOperations_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperations_InventoryId",
                table: "InventoryOperations",
                column: "InventoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryOperations");
        }
    }
}