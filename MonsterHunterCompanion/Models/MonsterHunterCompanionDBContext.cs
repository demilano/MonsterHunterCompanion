using BowCompanion.Models.DamageCalculator.Weapons.ProwlerWeapon;
using MonsterHunterCompanion.Models.DamageCalculator;
using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models
{
    public class MonsterHunterCompanionDBContext : DbContext
    {
        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<ChargeLevel> ChargeLevels { get; set; }
        public DbSet<Shot> Shots { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }

        public DbSet<Bow> Bows { get; set; }
        public DbSet<Charge> Charges { get; set; }

        public DbSet<ProwlerWeapon> ProwlerWeapons { get; set; }

        public DbSet<MonsterHunterCompanion.Models.Palico.Palico> Palico { get; set; }
        public DbSet<PalicoSkill> PalicoSkills { get; set; }
        public DbSet<VillageProbability> VillageProbabilities { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<SkillGroup> PalicoSkillGroups { get; set; }
        public DbSet<SkillType> PalicoSkillTypes { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SkillPattern> SkillPatterns { get; set; }
        public DbSet<Bias> Biases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here
            base.OnModelCreating(modelBuilder);
        }
    }
}