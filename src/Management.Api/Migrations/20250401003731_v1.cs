using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Management.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseType_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    NormalizedName = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    ClaimValue = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWID()"),
                    UserName = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "BIT", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(11)", maxLength: 11, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    ClaimValue = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    ProviderKey = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin_UserId_LoginProvider_ProviderKey", x => new { x.UserId, x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    RoleId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole_UserId_RoleId", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    LoginProvider = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR(755)", maxLength: 755, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserToken_UserId_LoginProvider_Name", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.InsertData(
                table: "ExpenseType",
                columns: new[] { "Id", "CreatedAt", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("0df6645d-75d1-4c53-b4c4-2f180ccce785"), new DateTime(2025, 4, 1, 0, 37, 28, 96, DateTimeKind.Utc).AddTicks(9649), "Aquisição de prateleiras, armários, geladeiras, freezers e outros itens para armazenar ingredientes e produtos de forma adequada.", "Compras de Itens de Armazenamento" },
                    { new Guid("10fc264a-e211-4721-8901-868596ed1c45"), new DateTime(2025, 4, 1, 0, 37, 28, 96, DateTimeKind.Utc).AddTicks(9647), "Compra de equipamentos e utensílios necessários para a preparação dos lanches, como fogões, fritadeiras, fornos, grill, liquidificadores e outros.", "Compras de Equipamentos de Cozinha" },
                    { new Guid("17f83b24-bfa2-4d3c-892e-3f0e4cc391c8"), new DateTime(2025, 4, 1, 0, 37, 28, 96, DateTimeKind.Utc).AddTicks(9651), "Compra de materiais de escritório, como canetas, papéis, fichários, e outros itens necessários para o funcionamento administrativo da lanchonete.", "Compras de Suprimentos de Escritório" },
                    { new Guid("1ce28beb-2682-4279-90e2-3f3d219d1d09"), new DateTime(2025, 4, 1, 0, 37, 28, 96, DateTimeKind.Utc).AddTicks(9652), "Aquisição de uniformes para os funcionários, como aventais, camisetas, bonés e calçados adequados para a rotina da lanchonete.", "Compras de Roupas e Uniformes" },
                    { new Guid("502ca69e-0e90-42dd-8fa1-737f59f069f0"), new DateTime(2025, 4, 1, 0, 37, 28, 96, DateTimeKind.Utc).AddTicks(8863), "Aquisição de ingredientes essenciais para a produção de lanches, como pães, queijos, carnes, vegetais e molhos.", "Compras de Ingredientes para Lanches" },
                    { new Guid("5b51f5ec-b926-4682-a6c9-30c21ccea0e7"), new DateTime(2025, 4, 1, 0, 37, 28, 96, DateTimeKind.Utc).AddTicks(9623), "Compra de refrigerantes, sucos, águas e outras bebidas que acompanham os lanches oferecidos aos clientes.", "Compras de Bebidas" },
                    { new Guid("812d8a75-f10a-45b0-abbd-e3db1391af6a"), new DateTime(2025, 4, 1, 0, 37, 28, 96, DateTimeKind.Utc).AddTicks(9640), "Compra de ingredientes para preparar salgados como coxinhas, empadas, pastéis, e outros itens fritos ou assados.", "Compras de Ingredientes para Salgados" },
                    { new Guid("84adb68f-66e1-4674-97af-66996c21b49e"), new DateTime(2025, 4, 1, 0, 37, 28, 96, DateTimeKind.Utc).AddTicks(9638), "Aquisição de doces e sobremesas, como bolos, tortas, brownies, e outros produtos de confeitaria para acompanhar o cardápio.", "Compras de Produtos de Confeitaria" },
                    { new Guid("a44ab9eb-01eb-4fac-b90d-ea4d1e1678e7"), new DateTime(2025, 4, 1, 0, 37, 28, 96, DateTimeKind.Utc).AddTicks(9645), "Aquisição de produtos para manter o ambiente da lanchonete limpo e higienizado, como detergentes, desinfetantes, esponjas e toalhas.", "Compras de Produtos de Limpeza" },
                    { new Guid("de1aefd3-aa1b-4421-8c1e-e88f01f4a40c"), new DateTime(2025, 4, 1, 0, 37, 28, 96, DateTimeKind.Utc).AddTicks(9642), "Compra de utensílios para a preparação e embalagem dos lanches, como facas, tábuas de corte, embalagens para delivery, sacolas e caixas.", "Compras de Utensílios e Embalagens" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_NormalizedName",
                table: "IdentityRole",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_NormalizedUserName",
                table: "IdentityUser",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "IdentityUser",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseType");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "IdentityRoleClaim");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin");

            migrationBuilder.DropTable(
                name: "IdentityUserRole");

            migrationBuilder.DropTable(
                name: "IdentityUserToken");
        }
    }
}
