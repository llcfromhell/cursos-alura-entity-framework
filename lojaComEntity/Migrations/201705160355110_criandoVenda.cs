namespace lojaComEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criandoVenda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "CategoriaID", "dbo.Categorias");
            DropPrimaryKey("dbo.Usuarios");
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.ProdutoVendas",
                c => new
                    {
                        VendaID = c.Int(nullable: false),
                        ProdutoTopID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VendaID, t.ProdutoTopID })
                .ForeignKey("dbo.ProdutoTops", t => t.ProdutoTopID)
                .ForeignKey("dbo.Vendas", t => t.VendaID)
                .Index(t => t.VendaID)
                .Index(t => t.ProdutoTopID);
            
            CreateTable(
                "dbo.ProdutoTops",
                c => new
                    {
                        ProdutoTopID = c.Int(nullable: false, identity: true),
                        nome = c.String(maxLength: 150, unicode: false),
                        preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProdutoTopID);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VendaID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID)
                .Index(t => t.ClienteID);
            
            AlterColumn("dbo.Categorias", "Nome", c => c.String(maxLength: 150, unicode: false));
            AlterColumn("dbo.Produtoes", "Nome", c => c.String(maxLength: 150, unicode: false));
            AlterColumn("dbo.Usuarios", "Nome", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Usuarios", "Senha", c => c.String(maxLength: 150, unicode: false));
            AddPrimaryKey("dbo.Usuarios", "Nome");
            AddForeignKey("dbo.Produtoes", "CategoriaID", "dbo.Categorias", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.ProdutoVendas", "VendaID", "dbo.Vendas");
            DropForeignKey("dbo.Vendas", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.ProdutoVendas", "ProdutoTopID", "dbo.ProdutoTops");
            DropIndex("dbo.Vendas", new[] { "ClienteID" });
            DropIndex("dbo.ProdutoVendas", new[] { "ProdutoTopID" });
            DropIndex("dbo.ProdutoVendas", new[] { "VendaID" });
            DropPrimaryKey("dbo.Usuarios");
            AlterColumn("dbo.Usuarios", "Senha", c => c.String());
            AlterColumn("dbo.Usuarios", "Nome", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Produtoes", "Nome", c => c.String());
            AlterColumn("dbo.Categorias", "Nome", c => c.String());
            DropTable("dbo.Vendas");
            DropTable("dbo.ProdutoTops");
            DropTable("dbo.ProdutoVendas");
            DropTable("dbo.Clientes");
            AddPrimaryKey("dbo.Usuarios", "Nome");
            AddForeignKey("dbo.Produtoes", "CategoriaID", "dbo.Categorias", "ID", cascadeDelete: true);
        }
    }
}
