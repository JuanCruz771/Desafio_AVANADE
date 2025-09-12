using System.ComponentModel.DataAnnotations;

namespace Desafio_e_commerce_AVANADE_Vendas.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Genero { get; set; }
        public DateOnly Data_Nascimento { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Endereço { get; set; }
        public Tipo_Usuario Tipo { get; set; }

       
        
    }
}
