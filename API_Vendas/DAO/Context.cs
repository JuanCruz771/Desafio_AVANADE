using Desafio_e_commerce_AVANADE_Vendas.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_e_commerce_AVANADE_Vendas.DAO
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Registro_Vendas> Registro_Venda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Mapear relacionamento com Produtos sem recriar a tabela
            modelBuilder.Entity<Registro_Vendas>()
                .HasOne(rv => rv.Produto)
                .WithMany()
                .HasForeignKey(rv => rv.Id_Produto)
                .HasConstraintName("FK_Registro_Vendas_Produtos");

            // Dizer explicitamente que Produtos já existe
            modelBuilder.Entity<Produtos>()
                .ToTable("Produtos")   // usa tabela já existente
                .HasKey(p => p.Id);    // define a PK existente

            // Configuração Comprador
            modelBuilder.Entity<Registro_Vendas>()
                .HasOne(rv => rv.Comprador)
                .WithMany()
                .HasForeignKey(rv => rv.Id_Comprador)
                .HasConstraintName("FK_Registro_Vendas_Comprador");

            // Configuração Vendedor
            modelBuilder.Entity<Registro_Vendas>()
                .HasOne(rv => rv.Vendedor)
                .WithMany()
                .HasForeignKey(rv => rv.Id_Vendedor)
                .HasConstraintName("FK_Registro_Vendas_Vendedor");

            base.OnModelCreating(modelBuilder);
        }

    }
}
