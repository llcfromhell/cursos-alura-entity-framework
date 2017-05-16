using lojaComEntity.Context;
using lojaComEntity.Dao;
using lojaComEntity.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity
{
    class Program
    {

        static LojaContext ctx = new LojaContext();

        static void Main(string[] args)
        {

            //saveUsuario();
            //saveProdutoComCategoria();
            //showCategoriaPaoFrances();
            //buscaTodosOsProdutosEmOrdemAlfabetica();
            //todosOsProdutos();
            //produtosComPrecoMaiorQue100();
            //buscaProdutosMaisCarosQue100EmOrdemAlfabetica();
            //produtosComPrecoMaiorQue100EPadaria();
            //buscaProdutosPorNomeOuCategoria(null, "Padaria");

            //buscaProdutosPorNomeOuCategoria("Pastel" , null);

            //buscaProdutosPorNomeOuCategoria("Bolo", "Salgados");

            //produtosPorNomeOuCategoria(null, "Padaria");

            //produtosPorNomeOuCategoria("Pastel", null);

            //produtosPorNomeOuCategoria("Bolo", "Salgados");

            criaUmaVenda();
            mostraVendas();


        }

        private static void criaUmaVenda()
        {

            Console.WriteLine("Gerando nova venda");
            Console.WriteLine("------");

            /* gera um array random de produtos para cada venda ser "diferente" */
            Random r = new Random();
            int randomSize = r.Next(1, ctx.ProdutoTops.Count());
            int[] ids = ctx.ProdutoTops.Select(p => p.ProdutoTopID).ToArray();

            List<ProdutoVenda> pvList = new List<ProdutoVenda>();

            for (int i = 0; i < randomSize; i++)
            {
                int randomIdx = r.Next(0, randomSize);
                int randomId = ids[randomIdx];
                pvList.Add(new ProdutoVenda { ProdutoTop = ctx.ProdutoTops.Find(randomId) });
            }

            Cliente cliente = ctx.Clientes.FirstOrDefault();

            Venda v = new Venda { Cliente = cliente, ProdutoVenda = pvList };

            ctx.Vendas.Add(v);
            ctx.SaveChanges();

        }

        private static void mostraVendas()
        {
            Console.WriteLine("Mostrando todas as vendas");
            Console.WriteLine("------");
            ctx.
                Vendas.
                ToList().
                ForEach(v => Console.WriteLine(v.VendaID + " - " + v.Cliente.Nome + " - " + v.ProdutoVenda.Select(pv => pv.ProdutoTop.nome).Aggregate( (c,n) => c + (n == null ? "." : ", " + n) )));
        }

        private static string produtosNaVenda(Venda v)
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }

        private static void buscaProdutosPorNomeOuCategoria(string nome, string categoria)
        {
            
            Console.WriteLine("Produtos por nome AND categoria");
            Console.WriteLine("------");
            Console.WriteLine("Prod => " + nome);
            Console.WriteLine("Cat => " + categoria);
            Console.WriteLine("------");

            var produtos = ctx.Produtos.Select(p => p);

            if (!String.IsNullOrEmpty(nome)) produtos = produtos.Where(p => p.Nome.Contains(nome));
            if (!String.IsNullOrEmpty(categoria)) produtos = produtos.Where(p => p.Categoria.Nome.Contains(categoria));

            produtos.ToList().ForEach(p => Console.WriteLine(p.Nome));

            Console.WriteLine("");

        }

        private static void produtosPorNomeOuCategoria(string nome, string categoria)
        {

            Console.WriteLine("Produtos por nome AND categoria");
            Console.WriteLine("------");
            Console.WriteLine("Prod => " + nome);
            Console.WriteLine("Cat => " + categoria);
            Console.WriteLine("------");


            var produtos = from p in ctx.Produtos select p;

            if (!String.IsNullOrEmpty(nome)) produtos = from p in produtos where p.Nome.Contains(nome) select p;

            if (!String.IsNullOrEmpty(categoria)) produtos = from p in produtos where p.Categoria.Nome.Contains(categoria) select p;

            produtos.ToList().ForEach(p => Console.WriteLine(p.Nome));

            Console.WriteLine("");

        }

        private static void buscaProdutosMaisCarosQue100EmOrdemAlfabetica()
        {

            Console.WriteLine("Produtos com preço maior que 100");
            Console.WriteLine("------");

            ctx
                .Produtos
                .Where(p => p.Preco > 100)
                .OrderBy(p => p.Nome)
                .ToList()
                .ForEach(p => Console.WriteLine(p.Nome));

        }

        private static void produtosComPrecoMaiorQue100EPadaria()
        {

            Console.WriteLine("Produtos com preço maior que 100 e da Padaria");
            Console.WriteLine("------");

            var busca = from p in ctx.Produtos where p.Preco > 100 && p.Categoria.Nome == "Padaria" orderby p.Nome select p;
            busca.ToList().ForEach(p => Console.WriteLine(p.Nome));

        }

        private static void produtosComPrecoMaiorQue100()
        {

            Console.WriteLine("Produtos com preço maior que 100");
            Console.WriteLine("------");

            var busca = from p in ctx.Produtos where p.Preco > 100 orderby p.Nome select p;
            busca.ToList().ForEach(p => Console.WriteLine(p.Nome));

        }

        private static void buscaTodosOsProdutosEmOrdemAlfabetica()
        {

            Console.WriteLine("Todos os produtos em ordem alfabética");
            Console.WriteLine("------");

            ctx
                .Produtos
                .Select(p => p)
                .OrderBy(p => p.Nome)
                .ToList()
                .ForEach(p => Console.WriteLine(p.Nome));

        }

        private static void todosOsProdutos()
        {

            Console.WriteLine("Todos os produtos em ordem alfabética");
            Console.WriteLine("------");

            var busca = from p in ctx.Produtos orderby p.Nome select p;

            foreach (var produto in busca)
            {
                Console.WriteLine(produto.Nome);
            }
            
        }

        private static void saveUsuario()
        {
            UsuarioDao dao = new UsuarioDao();
            Usuario ross = new Usuario()
            {
                Nome = "ross two",
                Senha = "123456"
            };

            dao.create(ross);
            Console.WriteLine("Usuário salvo com sucesso");
        }

        private static void showCategoriaPaoFrances()
        {
            Console.WriteLine(new ProdutoDao().findBy("Pão frances").Categoria.Nome);
        }

        private static void saveProdutoComCategoria()
        {

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
