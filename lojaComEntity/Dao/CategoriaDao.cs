using lojaComEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity.Dao
{
    public class CategoriaDao : AbstractDao
    {
        public void create(Categoria o)
        {
            ctx.Categorias.Add(o);
            saveSchanges();
        }
        public void saveSchanges()
        {
            ctx.SaveChanges();
        }
        public void delete(Categoria o)
        {
            ctx.Categorias.Remove(o);
            saveSchanges();
        }

        public Categoria findBy(String nome)
        {
            return ctx.Categorias.FirstOrDefault(u => u.Nome == nome);
        }
    }
}
