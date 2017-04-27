using lojaComEntity.Context;
using lojaComEntity.Dao;
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

            //saveProdutoComCategoria();

            Console.WriteLine(new ProdutoDao().findBy("Pão frances").Categoria.Nome);
            Console.ReadLine();

        }

        private static void saveUsuario()
        {
            UsuarioDao dao = new UsuarioDao();
            Usuario ross = new Usuario()
            {
                Nome = "chandler",
                Senha = "123"
            };

            dao.create(ross);
        }

        private static void saveProdutoComCategoria()
        {
            LojaContext ctx = new LojaContext("LojaContextConnectionString");

            Categoria c = new Categoria()
            {
                Nome = "Padaria"
            };
            ctx.Categorias.Add(c);
            ctx.SaveChanges();

            Produto p = new Produto()
            {
                Nome = "Pão frances",
                Preco = 1.0M,
                Categoria = c
            };
            ctx.Produtos.Add(p);
            ctx.SaveChanges();
        }
    }
}
