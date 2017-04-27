using lojaComEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity.Context
{
    public class LojaContext : DbContext
    {

        public LojaContext(string connection) : base(connection) { }

        public LojaContext() { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
