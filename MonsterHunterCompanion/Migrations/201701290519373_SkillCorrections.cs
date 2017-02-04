namespace MonsterHunterCompanion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillCorrections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SkillGroups", "GroupDescription", c => c.String());
            DropColumn("dbo.PalicoSkills", "PrimarySkill");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PalicoSkills", "PrimarySkill", c => c.Boolean(nullable: false));
            DropColumn("dbo.SkillGroups", "GroupDescription");
        }
    }
}
