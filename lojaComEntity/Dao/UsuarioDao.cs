using lojaComEntity.Context;
using lojaComEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity.Dao
{
    public class UsuarioDao : AbstractDao
    {

        public void create(Usuario o) {
            ctx.Usuarios.Add(o);
            saveSchanges();
        }
        public void saveSchanges() {
            ctx.SaveChanges();
        }
        public void delete(Usuario o) {
            ctx.Usuarios.Remove(o);
            saveSchanges();
        }

        public Usuario findBy(String nome) {
            return ctx.Usuarios.FirstOrDefault(u => u.Nome == nome);
        }

    }
}
