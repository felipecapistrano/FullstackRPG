namespace FullstackRPG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Materials", newName: "Materiais");
            RenameTable(name: "dbo.Personagems", newName: "Personagens");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Personagens", newName: "Personagems");
            RenameTable(name: "dbo.Materiais", newName: "Materials");
        }
    }
}
