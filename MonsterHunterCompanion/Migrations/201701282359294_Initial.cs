namespace MonsterHunterCompanion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        WeaponId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayRaw = c.Int(nullable: false),
                        DisplayElementDamage = c.Int(nullable: false),
                        Element = c.Int(nullable: false),
                        DisplayAffinity = c.Int(nullable: false),
                        WeaponType_WeaponTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.WeaponId)
                .ForeignKey("dbo.WeaponTypes", t => t.WeaponType_WeaponTypeId)
                .Index(t => t.WeaponType_WeaponTypeId);
            
            CreateTable(
                "dbo.WeaponTypes",
                c => new
                    {
                        WeaponTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Factor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.WeaponTypeId);
            
            CreateTable(
                "dbo.Charges",
                c => new
                    {
                        ChargeId = c.Int(nullable: false, identity: true),
                        ShotId = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChargeId)
                .ForeignKey("dbo.ChargeLevels", t => t.Level, cascadeDelete: true)
                .ForeignKey("dbo.Shots", t => t.ShotId, cascadeDelete: true)
                .Index(t => t.Level)
                .Index(t => t.ShotId);
            
            CreateTable(
                "dbo.ChargeLevels",
                c => new
                    {
                        Level = c.Int(nullable: false, identity: true),
                        RawDecimalModifier = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ElementDecimalModifier = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Level);
            
            CreateTable(
                "dbo.Shots",
                c => new
                    {
                        ShotId = c.Int(nullable: false, identity: true),
                        ShotLevel = c.Int(nullable: false),
                        NumberOfArrows = c.Int(nullable: false),
                        ShotType = c.Int(nullable: false),
                        MotionValuePercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShotId);
            
            CreateTable(
                "dbo.Palicoes",
                c => new
                    {
                        PalicoId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BiasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PalicoId)
                .ForeignKey("dbo.Bias", t => t.BiasId, cascadeDelete: true)
                .Index(t => t.BiasId);
            
            CreateTable(
                "dbo.Bias",
                c => new
                    {
                        BiasId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MaxSkillCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BiasId);
            
            CreateTable(
                "dbo.PalicoSkills",
                c => new
                    {
                        PalicoSkillId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SkillTypeId = c.Int(nullable: false),
                        SkillGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PalicoSkillId)
                .ForeignKey("dbo.SkillTypes", t => t.SkillTypeId, cascadeDelete: true)
                .ForeignKey("dbo.SkillGroups", t => t.SkillGroupId, cascadeDelete: true)
                .Index(t => t.SkillTypeId)
                .Index(t => t.SkillGroupId);
            
            CreateTable(
                "dbo.SkillTypes",
                c => new
                    {
                        SkillTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SkillTypeId);
            
            CreateTable(
                "dbo.SkillGroups",
                c => new
                    {
                        SkillGroupId = c.Int(nullable: false, identity: true),
                        Group = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillGroupId);
            
            CreateTable(
                "dbo.VillageProbabilities",
                c => new
                    {
                        VillageProbabilityId = c.Int(nullable: false, identity: true),
                        Probability = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VillageId = c.Int(nullable: false),
                        PalicoSkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VillageProbabilityId)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: true)
                .ForeignKey("dbo.PalicoSkills", t => t.PalicoSkillId, cascadeDelete: true)
                .Index(t => t.VillageId)
                .Index(t => t.PalicoSkillId);
            
            CreateTable(
                "dbo.Villages",
                c => new
                    {
                        VillageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.VillageId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SettingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.SettingId);
            
            CreateTable(
                "dbo.SkillPatterns",
                c => new
                    {
                        SkillPatternId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.SkillPatternId);
            
            CreateTable(
                "dbo.SkillPatternItems",
                c => new
                    {
                        SkillPatternItemId = c.Int(nullable: false, identity: true),
                        SkillPatternId = c.Int(nullable: false),
                        SkillGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillPatternItemId)
                .ForeignKey("dbo.SkillPatterns", t => t.SkillPatternId, cascadeDelete: true)
                .ForeignKey("dbo.SkillGroups", t => t.SkillGroupId, cascadeDelete: true)
                .Index(t => t.SkillPatternId)
                .Index(t => t.SkillGroupId);
            
            CreateTable(
                "dbo.ChargeBows",
                c => new
                    {
                        Charge_ChargeId = c.Int(nullable: false),
                        Bow_WeaponId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Charge_ChargeId, t.Bow_WeaponId })
                .ForeignKey("dbo.Charges", t => t.Charge_ChargeId, cascadeDelete: true)
                .ForeignKey("dbo.Bows", t => t.Bow_WeaponId, cascadeDelete: true)
                .Index(t => t.Charge_ChargeId)
                .Index(t => t.Bow_WeaponId);
            
            CreateTable(
                "dbo.Bows",
                c => new
                    {
                        WeaponId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeaponId)
                .ForeignKey("dbo.Weapons", t => t.WeaponId)
                .Index(t => t.WeaponId);
            
            CreateTable(
                "dbo.ProwlerWeapons",
                c => new
                    {
                        WeaponId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeaponId)
                .ForeignKey("dbo.Weapons", t => t.WeaponId)
                .Index(t => t.WeaponId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProwlerWeapons", new[] { "WeaponId" });
            DropIndex("dbo.Bows", new[] { "WeaponId" });
            DropIndex("dbo.ChargeBows", new[] { "Bow_WeaponId" });
            DropIndex("dbo.ChargeBows", new[] { "Charge_ChargeId" });
            DropIndex("dbo.SkillPatternItems", new[] { "SkillGroupId" });
            DropIndex("dbo.SkillPatternItems", new[] { "SkillPatternId" });
            DropIndex("dbo.VillageProbabilities", new[] { "PalicoSkillId" });
            DropIndex("dbo.VillageProbabilities", new[] { "VillageId" });
            DropIndex("dbo.PalicoSkills", new[] { "SkillGroupId" });
            DropIndex("dbo.PalicoSkills", new[] { "SkillTypeId" });
            DropIndex("dbo.Palicoes", new[] { "BiasId" });
            DropIndex("dbo.Charges", new[] { "ShotId" });
            DropIndex("dbo.Charges", new[] { "Level" });
            DropIndex("dbo.Weapons", new[] { "WeaponType_WeaponTypeId" });
            DropForeignKey("dbo.ProwlerWeapons", "WeaponId", "dbo.Weapons");
            DropForeignKey("dbo.Bows", "WeaponId", "dbo.Weapons");
            DropForeignKey("dbo.ChargeBows", "Bow_WeaponId", "dbo.Bows");
            DropForeignKey("dbo.ChargeBows", "Charge_ChargeId", "dbo.Charges");
            DropForeignKey("dbo.SkillPatternItems", "SkillGroupId", "dbo.SkillGroups");
            DropForeignKey("dbo.SkillPatternItems", "SkillPatternId", "dbo.SkillPatterns");
            DropForeignKey("dbo.VillageProbabilities", "PalicoSkillId", "dbo.PalicoSkills");
            DropForeignKey("dbo.VillageProbabilities", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.PalicoSkills", "SkillGroupId", "dbo.SkillGroups");
            DropForeignKey("dbo.PalicoSkills", "SkillTypeId", "dbo.SkillTypes");
            DropForeignKey("dbo.Palicoes", "BiasId", "dbo.Bias");
            DropForeignKey("dbo.Charges", "ShotId", "dbo.Shots");
            DropForeignKey("dbo.Charges", "Level", "dbo.ChargeLevels");
            DropForeignKey("dbo.Weapons", "WeaponType_WeaponTypeId", "dbo.WeaponTypes");
            DropTable("dbo.ProwlerWeapons");
            DropTable("dbo.Bows");
            DropTable("dbo.ChargeBows");
            DropTable("dbo.SkillPatternItems");
            DropTable("dbo.SkillPatterns");
            DropTable("dbo.Settings");
            DropTable("dbo.Villages");
            DropTable("dbo.VillageProbabilities");
            DropTable("dbo.SkillGroups");
            DropTable("dbo.SkillTypes");
            DropTable("dbo.PalicoSkills");
            DropTable("dbo.Bias");
            DropTable("dbo.Palicoes");
            DropTable("dbo.Shots");
            DropTable("dbo.ChargeLevels");
            DropTable("dbo.Charges");
            DropTable("dbo.WeaponTypes");
            DropTable("dbo.Weapons");
        }
    }
}
