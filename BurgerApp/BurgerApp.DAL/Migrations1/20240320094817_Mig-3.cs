using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraMetarialOrderDetail");

           
            migrationBuilder.CreateTable(
                name: "ExtraMaterialOrderDetail",
                columns: table => new
                {
                    DetailsId = table.Column<int>(type: "int", nullable: false),
                    ExtraMetarialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraMaterialOrderDetail", x => new { x.DetailsId, x.ExtraMetarialsId });
                    table.ForeignKey(
                        name: "FK_ExtraMaterialOrderDetail_ExtraMetarials_ExtraMetarialsId",
                        column: x => x.ExtraMetarialsId,
                        principalTable: "ExtraMetarials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraMaterialOrderDetail_OrderDetails_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraMaterialOrderDetail_ExtraMetarialsId",
                table: "ExtraMaterialOrderDetail",
                column: "ExtraMetarialsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
