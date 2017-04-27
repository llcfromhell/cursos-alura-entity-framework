using lojaComEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity.Dao
{
    public class ProdutoDao : AbstractDao
    {
        public void create(Produto o)
        {
            ctx.Produtos.Add(o);
            saveSchanges();
        }
        public void saveSchanges()
        {
            ctx.SaveChanges();
        }
        public void delete(Produto o)
        {
            ctx.Produtos.Remove(o);
            saveSchanges();
        }

        public Produto findBy(String nome)
        {
            return ctx.Produtos.FirstOrDefault(u => u.Nome == nome);
        }
    }
}
