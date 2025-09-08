using Desafio_e_commerce_AVANADE_Vendas.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_e_commerce_AVANADE_Vendas.DAO
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
