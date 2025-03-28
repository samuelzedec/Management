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
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Id", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("57cfd337-a0d3-499c-b37f-93ac72dc3a72"), new DateTime(2025, 3, 28, 0, 32, 13, 216, DateTimeKind.Utc).AddTicks(7821), "Compra de ingredientes para preparar salgados como coxinhas, empadas, pastéis, e outros itens fritos ou assados.", "Compras de Ingredientes para Salgados" },
                    { new Guid("641229e3-ec5b-4f87-9ac0-527790d42777"), new DateTime(2025, 3, 28, 0, 32, 13, 216, DateTimeKind.Utc).AddTicks(7916), "Compra de materiais de escritório, como canetas, papéis, fichários, e outros itens necessários para o funcionamento administrativo da lanchonete.", "Compras de Suprimentos de Escritório" },
                    { new Guid("86ec76ae-070f-44ea-a948-9cf758196747"), new DateTime(2025, 3, 28, 0, 32, 13, 216, DateTimeKind.Utc).AddTicks(7897), "Aquisição de prateleiras, armários, geladeiras, freezers e outros itens para armazenar ingredientes e produtos de forma adequada.", "Compras de Itens de Armazenamento" },
                    { new Guid("96caa642-c034-405c-b70c-96532723593b"), new DateTime(2025, 3, 28, 0, 32, 13, 216, DateTimeKind.Utc).AddTicks(7408), "Aquisição de ingredientes essenciais para a produção de lanches, como pães, queijos, carnes, vegetais e molhos.", "Compras de Ingredientes para Lanches" },
                    { new Guid("bbf135f1-3287-418d-9400-d80be0a1ba07"), new DateTime(2025, 3, 28, 0, 32, 13, 216, DateTimeKind.Utc).AddTicks(7859), "Aquisição de produtos para manter o ambiente da lanchonete limpo e higienizado, como detergentes, desinfetantes, esponjas e toalhas.", "Compras de Produtos de Limpeza" },
                    { new Guid("c57b3c4d-1b45-45aa-9d7c-2770a08d48d9"), new DateTime(2025, 3, 28, 0, 32, 13, 216, DateTimeKind.Utc).AddTicks(7877), "Compra de equipamentos e utensílios necessários para a preparação dos lanches, como fogões, fritadeiras, fornos, grill, liquidificadores e outros.", "Compras de Equipamentos de Cozinha" },
                    { new Guid("d9966fc2-81fa-4fff-9831-33c677d277f3"), new DateTime(2025, 3, 28, 0, 32, 13, 216, DateTimeKind.Utc).AddTicks(7935), "Aquisição de uniformes para os funcionários, como aventais, camisetas, bonés e calçados adequados para a rotina da lanchonete.", "Compras de Roupas e Uniformes" },
                    { new Guid("f4349abd-f27a-4e11-b4b2-2b3a73a7cbf1"), new DateTime(2025, 3, 28, 0, 32, 13, 216, DateTimeKind.Utc).AddTicks(7840), "Compra de utensílios para a preparação e embalagem dos lanches, como facas, tábuas de corte, embalagens para delivery, sacolas e caixas.", "Compras de Utensílios e Embalagens" },
                    { new Guid("f5d41267-7c67-4493-90d1-d319374eabd6"), new DateTime(2025, 3, 28, 0, 32, 13, 216, DateTimeKind.Utc).AddTicks(7784), "Compra de refrigerantes, sucos, águas e outras bebidas que acompanham os lanches oferecidos aos clientes.", "Compras de Bebidas" },
                    { new Guid("f70a611c-5ce2-4c38-94ae-22da57826fe1"), new DateTime(2025, 3, 28, 0, 32, 13, 216, DateTimeKind.Utc).AddTicks(7802), "Aquisição de doces e sobremesas, como bolos, tortas, brownies, e outros produtos de confeitaria para acompanhar o cardápio.", "Compras de Produtos de Confeitaria" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
