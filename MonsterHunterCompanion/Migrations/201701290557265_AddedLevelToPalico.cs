namespace MonsterHunterCompanion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLevelToPalico : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Palicoes", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Palicoes", "Level");
        }
    }
}
