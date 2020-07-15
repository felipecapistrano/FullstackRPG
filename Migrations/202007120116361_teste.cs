namespace FullstackRPG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Habilidades", "PersonagemHabilidade_Id", "dbo.PersonagemHabilidades");
            DropForeignKey("dbo.Personagens", "PersonagemHabilidade_Id", "dbo.PersonagemHabilidades");
            DropIndex("dbo.Habilidades", new[] { "PersonagemHabilidade_Id" });
            DropIndex("dbo.Personagens", new[] { "PersonagemHabilidade_Id" });
            DropColumn("dbo.Habilidades", "PersonagemHabilidade_Id");
            DropColumn("dbo.Personagens", "PersonagemHabilidade_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personagens", "PersonagemHabilidade_Id", c => c.Int());
            AddColumn("dbo.Habilidades", "PersonagemHabilidade_Id", c => c.Int());
            CreateIndex("dbo.Personagens", "PersonagemHabilidade_Id");
            CreateIndex("dbo.Habilidades", "PersonagemHabilidade_Id");
            AddForeignKey("dbo.Personagens", "PersonagemHabilidade_Id", "dbo.PersonagemHabilidades", "Id");
            AddForeignKey("dbo.Habilidades", "PersonagemHabilidade_Id", "dbo.PersonagemHabilidades", "Id");
        }
    }
}
