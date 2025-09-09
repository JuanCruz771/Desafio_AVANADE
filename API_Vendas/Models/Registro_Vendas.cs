using System.ComponentModel.DataAnnotations;

namespace Desafio_e_commerce_AVANADE_Vendas.Models
{
    public class Registro_Vendas
    {
        [Key]
        public int Id { get; set; }

        // Foreign key para COMPRADOR
        public int Id_Comprador { get; set; }
        public Usuario? Comprador { get; set; }

        // Foreign key para VENDEDOR
        public int Id_Vendedor { get; set; }
        public Usuario? Vendedor { get; set; }

        // Foreign key para Produto
        public int Id_Produto { get; set; }
        public Produtos Produto { get; set; }

        public int Quantidade { get; set; }
        public decimal Valor_Total { get; set; }
        public string? Endereço_Venda { get; set; }
        public DateTime Data_Venda { get; set; }
        public Status_Venda Status_Venda { get; set; }
    }
}
