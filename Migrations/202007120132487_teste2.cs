namespace FullstackRPG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoArmas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Armas", "TipoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Armas", "TipoId");
            CreateIndex("dbo.PersonagemHabilidades", "PersonagemId");
            CreateIndex("dbo.PersonagemHabilidades", "HabilidadeId");
            AddForeignKey("dbo.Armas", "TipoId", "dbo.TipoArmas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonagemHabilidades", "HabilidadeId", "dbo.Habilidades", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonagemHabilidades", "PersonagemId", "dbo.Personagens", "Id", cascadeDelete: true);
            DropColumn("dbo.Armas", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Armas", "Tipo", c => c.String());
            DropForeignKey("dbo.PersonagemHabilidades", "PersonagemId", "dbo.Personagens");
            DropForeignKey("dbo.PersonagemHabilidades", "HabilidadeId", "dbo.Habilidades");
            DropForeignKey("dbo.Armas", "TipoId", "dbo.TipoArmas");
            DropIndex("dbo.PersonagemHabilidades", new[] { "HabilidadeId" });
            DropIndex("dbo.PersonagemHabilidades", new[] { "PersonagemId" });
            DropIndex("dbo.Armas", new[] { "TipoId" });
            DropColumn("dbo.Armas", "TipoId");
            DropTable("dbo.TipoArmas");
        }
    }
}
