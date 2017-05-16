namespace lojaComEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removendoPluralizacao : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categorias", newName: "Categoria");
            RenameTable(name: "dbo.Produtoes", newName: "Produto");
            RenameTable(name: "dbo.Clientes", newName: "Cliente");
            RenameTable(name: "dbo.ProdutoVendas", newName: "ProdutoVenda");
            RenameTable(name: "dbo.ProdutoTops", newName: "ProdutoTop");
            RenameTable(name: "dbo.Vendas", newName: "Venda");
            RenameTable(name: "dbo.Usuarios", newName: "Usuario");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Usuario", newName: "Usuarios");
            RenameTable(name: "dbo.Venda", newName: "Vendas");
            RenameTable(name: "dbo.ProdutoTop", newName: "ProdutoTops");
            RenameTable(name: "dbo.ProdutoVenda", newName: "ProdutoVendas");
            RenameTable(name: "dbo.Cliente", newName: "Clientes");
            RenameTable(name: "dbo.Produto", newName: "Produtoes");
            RenameTable(name: "dbo.Categoria", newName: "Categorias");
        }
    }
}
