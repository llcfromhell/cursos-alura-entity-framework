using lojaComEntity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity
{
    public class Class1
    {

        public static void main()
        {
            Usuario renan = new Usuario()
            {
                Nome = "Teste",
                Senha = "123"
            };

            LojaContext ctx = new LojaContext();

            ctx.Usuarios.Add(renan);
            ctx.SaveChanges();
            ctx.Dispose();
        }

    }
}
