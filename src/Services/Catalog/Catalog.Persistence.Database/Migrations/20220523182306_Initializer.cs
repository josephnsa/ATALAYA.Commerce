using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                schema: "Catalog",
                columns: table => new
                {
                    ProductStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.ProductStockId);
                    table.ForeignKey(
                        name: "FK_Stock_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Product",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 430m },
                    { 73, "Description for product 73", "Product 73", 145m },
                    { 72, "Description for product 72", "Product 72", 528m },
                    { 71, "Description for product 71", "Product 71", 950m },
                    { 70, "Description for product 70", "Product 70", 688m },
                    { 69, "Description for product 69", "Product 69", 836m },
                    { 68, "Description for product 68", "Product 68", 531m },
                    { 67, "Description for product 67", "Product 67", 801m },
                    { 66, "Description for product 66", "Product 66", 208m },
                    { 65, "Description for product 65", "Product 65", 723m },
                    { 64, "Description for product 64", "Product 64", 170m },
                    { 63, "Description for product 63", "Product 63", 669m },
                    { 62, "Description for product 62", "Product 62", 501m },
                    { 61, "Description for product 61", "Product 61", 873m },
                    { 60, "Description for product 60", "Product 60", 325m },
                    { 59, "Description for product 59", "Product 59", 864m },
                    { 58, "Description for product 58", "Product 58", 837m },
                    { 57, "Description for product 57", "Product 57", 691m },
                    { 56, "Description for product 56", "Product 56", 400m },
                    { 55, "Description for product 55", "Product 55", 774m },
                    { 54, "Description for product 54", "Product 54", 499m },
                    { 53, "Description for product 53", "Product 53", 491m },
                    { 74, "Description for product 74", "Product 74", 666m },
                    { 52, "Description for product 52", "Product 52", 536m },
                    { 75, "Description for product 75", "Product 75", 997m },
                    { 77, "Description for product 77", "Product 77", 404m },
                    { 98, "Description for product 98", "Product 98", 654m },
                    { 97, "Description for product 97", "Product 97", 823m },
                    { 96, "Description for product 96", "Product 96", 368m },
                    { 95, "Description for product 95", "Product 95", 100m },
                    { 94, "Description for product 94", "Product 94", 714m },
                    { 93, "Description for product 93", "Product 93", 647m },
                    { 92, "Description for product 92", "Product 92", 900m },
                    { 91, "Description for product 91", "Product 91", 926m },
                    { 90, "Description for product 90", "Product 90", 792m },
                    { 89, "Description for product 89", "Product 89", 486m },
                    { 88, "Description for product 88", "Product 88", 295m },
                    { 87, "Description for product 87", "Product 87", 135m },
                    { 86, "Description for product 86", "Product 86", 680m },
                    { 85, "Description for product 85", "Product 85", 779m },
                    { 84, "Description for product 84", "Product 84", 549m },
                    { 83, "Description for product 83", "Product 83", 884m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Product",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 82, "Description for product 82", "Product 82", 897m },
                    { 81, "Description for product 81", "Product 81", 793m },
                    { 80, "Description for product 80", "Product 80", 524m },
                    { 79, "Description for product 79", "Product 79", 432m },
                    { 78, "Description for product 78", "Product 78", 276m },
                    { 76, "Description for product 76", "Product 76", 977m },
                    { 51, "Description for product 51", "Product 51", 720m },
                    { 50, "Description for product 50", "Product 50", 876m },
                    { 49, "Description for product 49", "Product 49", 409m },
                    { 22, "Description for product 22", "Product 22", 129m },
                    { 21, "Description for product 21", "Product 21", 470m },
                    { 20, "Description for product 20", "Product 20", 767m },
                    { 19, "Description for product 19", "Product 19", 541m },
                    { 18, "Description for product 18", "Product 18", 984m },
                    { 17, "Description for product 17", "Product 17", 940m },
                    { 16, "Description for product 16", "Product 16", 689m },
                    { 15, "Description for product 15", "Product 15", 306m },
                    { 14, "Description for product 14", "Product 14", 929m },
                    { 13, "Description for product 13", "Product 13", 692m },
                    { 12, "Description for product 12", "Product 12", 496m },
                    { 11, "Description for product 11", "Product 11", 635m },
                    { 10, "Description for product 10", "Product 10", 840m },
                    { 9, "Description for product 9", "Product 9", 569m },
                    { 8, "Description for product 8", "Product 8", 995m },
                    { 7, "Description for product 7", "Product 7", 695m },
                    { 6, "Description for product 6", "Product 6", 817m },
                    { 5, "Description for product 5", "Product 5", 269m },
                    { 4, "Description for product 4", "Product 4", 424m },
                    { 3, "Description for product 3", "Product 3", 857m },
                    { 2, "Description for product 2", "Product 2", 982m },
                    { 23, "Description for product 23", "Product 23", 390m },
                    { 24, "Description for product 24", "Product 24", 119m },
                    { 25, "Description for product 25", "Product 25", 560m },
                    { 26, "Description for product 26", "Product 26", 944m },
                    { 48, "Description for product 48", "Product 48", 146m },
                    { 47, "Description for product 47", "Product 47", 250m },
                    { 46, "Description for product 46", "Product 46", 136m },
                    { 45, "Description for product 45", "Product 45", 686m },
                    { 44, "Description for product 44", "Product 44", 213m },
                    { 43, "Description for product 43", "Product 43", 724m },
                    { 42, "Description for product 42", "Product 42", 493m },
                    { 41, "Description for product 41", "Product 41", 770m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Product",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 40, "Description for product 40", "Product 40", 874m },
                    { 39, "Description for product 39", "Product 39", 939m },
                    { 99, "Description for product 99", "Product 99", 489m },
                    { 38, "Description for product 38", "Product 38", 511m },
                    { 36, "Description for product 36", "Product 36", 617m },
                    { 35, "Description for product 35", "Product 35", 192m },
                    { 34, "Description for product 34", "Product 34", 261m },
                    { 33, "Description for product 33", "Product 33", 695m },
                    { 32, "Description for product 32", "Product 32", 527m },
                    { 31, "Description for product 31", "Product 31", 216m },
                    { 30, "Description for product 30", "Product 30", 499m },
                    { 29, "Description for product 29", "Product 29", 425m },
                    { 28, "Description for product 28", "Product 28", 293m },
                    { 27, "Description for product 27", "Product 27", 944m },
                    { 37, "Description for product 37", "Product 37", 738m },
                    { 100, "Description for product 100", "Product 100", 577m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stock",
                columns: new[] { "ProductStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 15 },
                    { 73, 73, 14 },
                    { 72, 72, 10 },
                    { 71, 71, 9 },
                    { 70, 70, 0 },
                    { 69, 69, 7 },
                    { 68, 68, 4 },
                    { 67, 67, 15 },
                    { 66, 66, 16 },
                    { 65, 65, 14 },
                    { 64, 64, 3 },
                    { 63, 63, 17 },
                    { 62, 62, 19 },
                    { 61, 61, 4 },
                    { 60, 60, 2 },
                    { 59, 59, 10 },
                    { 58, 58, 14 },
                    { 57, 57, 6 },
                    { 56, 56, 17 },
                    { 55, 55, 16 },
                    { 54, 54, 6 },
                    { 53, 53, 3 },
                    { 74, 74, 15 },
                    { 52, 52, 13 },
                    { 75, 75, 13 },
                    { 77, 77, 16 },
                    { 98, 98, 17 },
                    { 97, 97, 4 },
                    { 96, 96, 6 },
                    { 95, 95, 6 },
                    { 94, 94, 5 },
                    { 93, 93, 13 },
                    { 92, 92, 14 },
                    { 91, 91, 5 },
                    { 90, 90, 6 },
                    { 89, 89, 17 },
                    { 88, 88, 1 },
                    { 87, 87, 3 },
                    { 86, 86, 16 },
                    { 85, 85, 10 },
                    { 84, 84, 1 },
                    { 83, 83, 18 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stock",
                columns: new[] { "ProductStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 82, 82, 10 },
                    { 81, 81, 4 },
                    { 80, 80, 12 },
                    { 79, 79, 19 },
                    { 78, 78, 5 },
                    { 76, 76, 2 },
                    { 51, 51, 14 },
                    { 50, 50, 12 },
                    { 49, 49, 18 },
                    { 22, 22, 17 },
                    { 21, 21, 3 },
                    { 20, 20, 19 },
                    { 19, 19, 6 },
                    { 18, 18, 2 },
                    { 17, 17, 14 },
                    { 16, 16, 18 },
                    { 15, 15, 12 },
                    { 14, 14, 11 },
                    { 13, 13, 18 },
                    { 12, 12, 3 },
                    { 11, 11, 3 },
                    { 10, 10, 4 },
                    { 9, 9, 8 },
                    { 8, 8, 10 },
                    { 7, 7, 17 },
                    { 6, 6, 16 },
                    { 5, 5, 6 },
                    { 4, 4, 0 },
                    { 3, 3, 17 },
                    { 2, 2, 13 },
                    { 23, 23, 6 },
                    { 24, 24, 3 },
                    { 25, 25, 9 },
                    { 26, 26, 4 },
                    { 48, 48, 0 },
                    { 47, 47, 19 },
                    { 46, 46, 17 },
                    { 45, 45, 4 },
                    { 44, 44, 0 },
                    { 43, 43, 1 },
                    { 42, 42, 1 },
                    { 41, 41, 6 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stock",
                columns: new[] { "ProductStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 40, 40, 11 },
                    { 39, 39, 7 },
                    { 99, 99, 6 },
                    { 38, 38, 4 },
                    { 36, 36, 12 },
                    { 35, 35, 3 },
                    { 34, 34, 14 },
                    { 33, 33, 8 },
                    { 32, 32, 6 },
                    { 31, 31, 9 },
                    { 30, 30, 5 },
                    { 29, 29, 13 },
                    { 28, 28, 17 },
                    { 27, 27, 11 },
                    { 37, 37, 8 },
                    { 100, 100, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductId",
                schema: "Catalog",
                table: "Product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                schema: "Catalog",
                table: "Stock",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Catalog");
        }
    }
}
