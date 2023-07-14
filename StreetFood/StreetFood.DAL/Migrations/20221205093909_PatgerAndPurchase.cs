using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreetFood.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PatgerAndPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Dishes_DishId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Ingredients_IngredientId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dishes_DishId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Ingredients_IngredientId",
                table: "StockProducts");

            migrationBuilder.DropIndex(
                name: "IX_StockProducts_IngredientId",
                table: "StockProducts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DishId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Contents_DishId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_IngredientId",
                table: "Contents");

            migrationBuilder.CreateTable(
                name: "Parther",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parther", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdIngredient = table.Column<int>(name: "Id_Ingredient", type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PartherId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Parther_PartherId",
                        column: x => x.PartherId,
                        principalTable: "Parther",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PartherId",
                table: "Purchase",
                column: "PartherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Parther");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_IngredientId",
                table: "StockProducts",
                column: "IngredientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DishId",
                table: "Orders",
                column: "DishId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_DishId",
                table: "Contents",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_IngredientId",
                table: "Contents",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Dishes_DishId",
                table: "Contents",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Ingredients_IngredientId",
                table: "Contents",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dishes_DishId",
                table: "Orders",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Ingredients_IngredientId",
                table: "StockProducts",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
