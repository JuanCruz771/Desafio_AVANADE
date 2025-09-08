using System.ComponentModel.DataAnnotations;

namespace Desafio_e_commerce_AVANADE_Vendas.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }
        public Tipo_Usuario Tipo { get; set; }
    }
}
