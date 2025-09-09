using System.ComponentModel.DataAnnotations;

namespace Desafio_e_commerce_AVANADE_Vendas.Models
{
    public class Produtos
    {
        [Key]
        public int Id { get; set; }
        public string? Codigo_interno { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
