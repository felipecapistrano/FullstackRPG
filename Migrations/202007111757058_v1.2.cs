namespace FullstackRPG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Habilidades", "PersonagemHabilidade_Id", c => c.Int());
            AddColumn("dbo.Personagens", "PersonagemPaiId", c => c.Int());
            AddColumn("dbo.Personagens", "PersonagemHabilidade_Id", c => c.Int());
            CreateIndex("dbo.Armaduras", "MaterialId");
            CreateIndex("dbo.Capacetes", "MaterialId");
            CreateIndex("dbo.Habilidades", "PersonagemHabilidade_Id");
            CreateIndex("dbo.Personagens", "RaçaId");
            CreateIndex("dbo.Personagens", "ArmaId");
            CreateIndex("dbo.Personagens", "CapaceteId");
            CreateIndex("dbo.Personagens", "ArmaduraId");
            CreateIndex("dbo.Personagens", "PersonagemPaiId");
            CreateIndex("dbo.Personagens", "PersonagemHabilidade_Id");
            AddForeignKey("dbo.Armaduras", "MaterialId", "dbo.Materiais", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Capacetes", "MaterialId", "dbo.Materiais", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Habilidades", "PersonagemHabilidade_Id", "dbo.PersonagemHabilidades", "Id");
            AddForeignKey("dbo.Personagens", "ArmaId", "dbo.Armas", "Id");
            AddForeignKey("dbo.Personagens", "ArmaduraId", "dbo.Armaduras", "Id");
            AddForeignKey("dbo.Personagens", "CapaceteId", "dbo.Capacetes", "Id");
            AddForeignKey("dbo.Personagens", "PersonagemPaiId", "dbo.Personagens", "Id");
            AddForeignKey("dbo.Personagens", "RaçaId", "dbo.Raça", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Personagens", "PersonagemHabilidade_Id", "dbo.PersonagemHabilidades", "Id");
            DropColumn("dbo.Personagens", "PersonagemPai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personagens", "PersonagemPai", c => c.Int());
            DropForeignKey("dbo.Personagens", "PersonagemHabilidade_Id", "dbo.PersonagemHabilidades");
            DropForeignKey("dbo.Personagens", "RaçaId", "dbo.Raça");
            DropForeignKey("dbo.Personagens", "PersonagemPaiId", "dbo.Personagens");
            DropForeignKey("dbo.Personagens", "CapaceteId", "dbo.Capacetes");
            DropForeignKey("dbo.Personagens", "ArmaduraId", "dbo.Armaduras");
            DropForeignKey("dbo.Personagens", "ArmaId", "dbo.Armas");
            DropForeignKey("dbo.Habilidades", "PersonagemHabilidade_Id", "dbo.PersonagemHabilidades");
            DropForeignKey("dbo.Capacetes", "MaterialId", "dbo.Materiais");
            DropForeignKey("dbo.Armaduras", "MaterialId", "dbo.Materiais");
            DropIndex("dbo.Personagens", new[] { "PersonagemHabilidade_Id" });
            DropIndex("dbo.Personagens", new[] { "PersonagemPaiId" });
            DropIndex("dbo.Personagens", new[] { "ArmaduraId" });
            DropIndex("dbo.Personagens", new[] { "CapaceteId" });
            DropIndex("dbo.Personagens", new[] { "ArmaId" });
            DropIndex("dbo.Personagens", new[] { "RaçaId" });
            DropIndex("dbo.Habilidades", new[] { "PersonagemHabilidade_Id" });
            DropIndex("dbo.Capacetes", new[] { "MaterialId" });
            DropIndex("dbo.Armaduras", new[] { "MaterialId" });
            DropColumn("dbo.Personagens", "PersonagemHabilidade_Id");
            DropColumn("dbo.Personagens", "PersonagemPaiId");
            DropColumn("dbo.Habilidades", "PersonagemHabilidade_Id");
        }
    }
}
