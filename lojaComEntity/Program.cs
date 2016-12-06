using lojaComEntity.Context;
using lojaComEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity
{
    class Program
    {
        static void Main(string[] args)
        {

            LojaContext contexto = new LojaContext("LojaContextConnectionString");
            Usuario ross = new Usuario()
            {
                Nome = "ross",
                Senha = "123"
            };
            contexto.Usuarios.Add(ross);
            contexto.SaveChanges();
            contexto.Dispose();
        }
    }
}
