using System.ComponentModel.DataAnnotations;

namespace Desafio_e_commerce_AVANADE_Estoque.Models
{
    public class Cadastro_Usuario
    {
        [Key]
        public int id  { get; set; }
        public string? Nome { get; set;}
        public string? Senha { get; set; }
        public string? Email { get; set; }
        public Tipo_usuario Tipo { get; set; }
    }
}
