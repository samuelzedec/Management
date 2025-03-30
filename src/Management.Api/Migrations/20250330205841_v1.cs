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
                    { new Guid("33ff78c7-a882-4407-b702-e10b47d5a5be"), new DateTime(2025, 3, 30, 20, 58, 40, 656, DateTimeKind.Utc).AddTicks(6274), "Compra de refrigerantes, sucos, águas e outras bebidas que acompanham os lanches oferecidos aos clientes.", "Compras de Bebidas" },
                    { new Guid("3eb07705-15a5-4136-a579-ca7022eab4d5"), new DateTime(2025, 3, 30, 20, 58, 40, 656, DateTimeKind.Utc).AddTicks(6406), "Compra de materiais de escritório, como canetas, papéis, fichários, e outros itens necessários para o funcionamento administrativo da lanchonete.", "Compras de Suprimentos de Escritório" },
                    { new Guid("4b447501-4219-436b-9e5c-b170815ea12b"), new DateTime(2025, 3, 30, 20, 58, 40, 656, DateTimeKind.Utc).AddTicks(6387), "Aquisição de prateleiras, armários, geladeiras, freezers e outros itens para armazenar ingredientes e produtos de forma adequada.", "Compras de Itens de Armazenamento" },
                    { new Guid("4cd034fb-ac05-4bc1-a0db-938bc254c646"), new DateTime(2025, 3, 30, 20, 58, 40, 656, DateTimeKind.Utc).AddTicks(5856), "Aquisição de ingredientes essenciais para a produção de lanches, como pães, queijos, carnes, vegetais e molhos.", "Compras de Ingredientes para Lanches" },
                    { new Guid("55546866-99c9-481a-94f8-583e11b867e2"), new DateTime(2025, 3, 30, 20, 58, 40, 656, DateTimeKind.Utc).AddTicks(6425), "Aquisição de uniformes para os funcionários, como aventais, camisetas, bonés e calçados adequados para a rotina da lanchonete.", "Compras de Roupas e Uniformes" },
                    { new Guid("6a6333b0-d33a-449b-a992-0f5fb7877acd"), new DateTime(2025, 3, 30, 20, 58, 40, 656, DateTimeKind.Utc).AddTicks(6311), "Compra de ingredientes para preparar salgados como coxinhas, empadas, pastéis, e outros itens fritos ou assados.", "Compras de Ingredientes para Salgados" },
                    { new Guid("9a4789ad-1698-485f-9263-cbbc679fca47"), new DateTime(2025, 3, 30, 20, 58, 40, 656, DateTimeKind.Utc).AddTicks(6349), "Aquisição de produtos para manter o ambiente da lanchonete limpo e higienizado, como detergentes, desinfetantes, esponjas e toalhas.", "Compras de Produtos de Limpeza" },
                    { new Guid("b5d93880-9df4-415c-9bf9-48e7a08e3bf5"), new DateTime(2025, 3, 30, 20, 58, 40, 656, DateTimeKind.Utc).AddTicks(6293), "Aquisição de doces e sobremesas, como bolos, tortas, brownies, e outros produtos de confeitaria para acompanhar o cardápio.", "Compras de Produtos de Confeitaria" },
                    { new Guid("b75b6705-2a26-49c6-9b0f-2ed5a6aba645"), new DateTime(2025, 3, 30, 20, 58, 40, 656, DateTimeKind.Utc).AddTicks(6331), "Compra de utensílios para a preparação e embalagem dos lanches, como facas, tábuas de corte, embalagens para delivery, sacolas e caixas.", "Compras de Utensílios e Embalagens" },
                    { new Guid("dee49e10-8f2c-4cb6-a972-6736877da55d"), new DateTime(2025, 3, 30, 20, 58, 40, 656, DateTimeKind.Utc).AddTicks(6369), "Compra de equipamentos e utensílios necessários para a preparação dos lanches, como fogões, fritadeiras, fornos, grill, liquidificadores e outros.", "Compras de Equipamentos de Cozinha" }
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
