namespace lojaComEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class herancaPessoas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150, unicode: false),
                        cpf = c.String(maxLength: 150, unicode: false),
                        cnpj = c.String(maxLength: 150, unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PessoaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoa");
        }
    }
}
