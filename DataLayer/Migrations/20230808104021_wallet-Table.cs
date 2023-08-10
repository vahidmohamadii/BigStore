using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class walletTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_users_UserId",
                table: "Wallet");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_WalletType_WalletTypeId",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletType",
                table: "WalletType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.RenameTable(
                name: "WalletType",
                newName: "walletTypes");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "wallets");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_WalletTypeId",
                table: "wallets",
                newName: "IX_wallets_WalletTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_UserId",
                table: "wallets",
                newName: "IX_wallets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_walletTypes",
                table: "walletTypes",
                column: "WalletTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wallets",
                table: "wallets",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_wallets_users_UserId",
                table: "wallets",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wallets_walletTypes_WalletTypeId",
                table: "wallets",
                column: "WalletTypeId",
                principalTable: "walletTypes",
                principalColumn: "WalletTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wallets_users_UserId",
                table: "wallets");

            migrationBuilder.DropForeignKey(
                name: "FK_wallets_walletTypes_WalletTypeId",
                table: "wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_walletTypes",
                table: "walletTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_wallets",
                table: "wallets");

            migrationBuilder.RenameTable(
                name: "walletTypes",
                newName: "WalletType");

            migrationBuilder.RenameTable(
                name: "wallets",
                newName: "Wallet");

            migrationBuilder.RenameIndex(
                name: "IX_wallets_WalletTypeId",
                table: "Wallet",
                newName: "IX_Wallet_WalletTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_wallets_UserId",
                table: "Wallet",
                newName: "IX_Wallet_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletType",
                table: "WalletType",
                column: "WalletTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_users_UserId",
                table: "Wallet",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_WalletType_WalletTypeId",
                table: "Wallet",
                column: "WalletTypeId",
                principalTable: "WalletType",
                principalColumn: "WalletTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
