namespace MonsterHunterCompanion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBiasAndPrimarySkill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PalicoSkills", "BiasId", c => c.Int());
            AddColumn("dbo.PalicoSkills", "PrimarySkill", c => c.Boolean(nullable: false));
            AddForeignKey("dbo.PalicoSkills", "BiasId", "dbo.Bias", "BiasId");
            CreateIndex("dbo.PalicoSkills", "BiasId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PalicoSkills", new[] { "BiasId" });
            DropForeignKey("dbo.PalicoSkills", "BiasId", "dbo.Bias");
            DropColumn("dbo.PalicoSkills", "PrimarySkill");
            DropColumn("dbo.PalicoSkills", "BiasId");
        }
    }
}
