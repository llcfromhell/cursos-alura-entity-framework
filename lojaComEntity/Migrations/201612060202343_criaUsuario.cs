namespace lojaComEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criaUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Nome = c.String(nullable: false, maxLength: 128),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Nome);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
