using Desafio_e_commerce_AVANADE_Estoque.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Desafio_e_commerce_AVANADE_Estoque.DAO
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Estoque_Produtos> Produtos { get; set; }
        

        
    }
}
