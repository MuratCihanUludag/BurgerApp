using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraMetarialOrderDetail_OrderDetail_DetailsId",
                table: "ExtraMetarialOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Burgers_BurgerId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Cipies_CipsId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Drinks_DrinkId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Menu_MenuId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailSauce_OrderDetail_DetailsId",
                table: "OrderDetailSauce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_MenuId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_DrinkId",
                table: "Menus",
                newName: "IX_Menus_DrinkId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_CipsId",
                table: "Menus",
                newName: "IX_Menus_CipsId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_BurgerId",
                table: "Menus",
                newName: "IX_Menus_BurgerId");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataStatu = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraMetarialOrderDetail_OrderDetails_DetailsId",
                table: "ExtraMetarialOrderDetail",
                column: "DetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Burgers_BurgerId",
                table: "Menus",
                column: "BurgerId",
                principalTable: "Burgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Cipies_CipsId",
                table: "Menus",
                column: "CipsId",
                principalTable: "Cipies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Drinks_DrinkId",
                table: "Menus",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Menus_MenuId",
                table: "OrderDetails",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailSauce_OrderDetails_DetailsId",
                table: "OrderDetailSauce",
                column: "DetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraMetarialOrderDetail_OrderDetails_DetailsId",
                table: "ExtraMetarialOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Burgers_BurgerId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Cipies_CipsId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Drinks_DrinkId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Menus_MenuId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailSauce_OrderDetails_DetailsId",
                table: "OrderDetailSauce");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_MenuId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_DrinkId",
                table: "Menu",
                newName: "IX_Menu_DrinkId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_CipsId",
                table: "Menu",
                newName: "IX_Menu_CipsId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_BurgerId",
                table: "Menu",
                newName: "IX_Menu_BurgerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraMetarialOrderDetail_OrderDetail_DetailsId",
                table: "ExtraMetarialOrderDetail",
                column: "DetailsId",
                principalTable: "OrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Burgers_BurgerId",
                table: "Menu",
                column: "BurgerId",
                principalTable: "Burgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Cipies_CipsId",
                table: "Menu",
                column: "CipsId",
                principalTable: "Cipies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Drinks_DrinkId",
                table: "Menu",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Menu_MenuId",
                table: "OrderDetail",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailSauce_OrderDetail_DetailsId",
                table: "OrderDetailSauce",
                column: "DetailsId",
                principalTable: "OrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
