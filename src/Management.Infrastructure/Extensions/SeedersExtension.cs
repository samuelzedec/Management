using Managment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Managment.Infrastructure.Extensions;

public static class SeedersExtension
{
    public static void SeedCategoryData(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Category>()
            .HasData(
                new Category("Compras de Ingredientes para Lanches",
                    "Aquisição de ingredientes essenciais para a produção de lanches, como pães, queijos, carnes, vegetais e molhos."),
                
                new Category("Compras de Bebidas",
                    "Compra de refrigerantes, sucos, águas e outras bebidas que acompanham os lanches oferecidos aos clientes."),
                
                new Category("Compras de Produtos de Confeitaria",
                    "Aquisição de doces e sobremesas, como bolos, tortas, brownies, e outros produtos de confeitaria para acompanhar o cardápio."),
                
                new Category("Compras de Ingredientes para Salgados",
                    "Compra de ingredientes para preparar salgados como coxinhas, empadas, pastéis, e outros itens fritos ou assados."),
                
                new Category("Compras de Utensílios e Embalagens",
                    "Compra de utensílios para a preparação e embalagem dos lanches, como facas, tábuas de corte, embalagens para delivery, sacolas e caixas."),
                
                new Category("Compras de Produtos de Limpeza",
                    "Aquisição de produtos para manter o ambiente da lanchonete limpo e higienizado, como detergentes, desinfetantes, esponjas e toalhas."),
                
                new Category("Compras de Equipamentos de Cozinha",
                    "Compra de equipamentos e utensílios necessários para a preparação dos lanches, como fogões, fritadeiras, fornos, grill, liquidificadores e outros."),
                
                new Category("Compras de Itens de Armazenamento",
                    "Aquisição de prateleiras, armários, geladeiras, freezers e outros itens para armazenar ingredientes e produtos de forma adequada."),
                
                new Category("Compras de Suprimentos de Escritório",
                    "Compra de materiais de escritório, como canetas, papéis, fichários, e outros itens necessários para o funcionamento administrativo da lanchonete."),
                
                new Category("Compras de Roupas e Uniformes",
                    "Aquisição de uniformes para os funcionários, como aventais, camisetas, bonés e calçados adequados para a rotina da lanchonete.")
            );
    }
}