using MonsterHunterCompanion.Migrations;
using MonsterHunterCompanion.Migrations.Initialisation;
using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.Models.DamageCalculator;
using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MonsterHunterCompanion.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MonsterHunterCompanionDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MonsterHunterCompanionDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.ChargeLevels.AddOrUpdate(
                GetChargesLevels.Get()  
            );

            context.Shots.AddOrUpdate(
                GetShots.Get()
            );

            // Atomics
            AddUpdatePalicoSkillTypes.AddOrUpdate(context);
            AddUpdatePalicoSkillGroups.AddOrUpdate(context);
            AddUpdateVillages.AddOrUpdate(context);
            AddUpdateBiases.AddOrUpdate(context);
            context.SaveChanges();

            AddUpdatePalicoSkills.AddOrUpdate(context);
            AddUpdatePatterns.AddOrUpdate(context);

            context.SaveChanges();

            AddUpdateVillageProbabilities.AddUpdate(context);


            


            context.WeaponTypes.AddOrUpdate(
                    new WeaponType()
                    {
                        Factor = 1.2M,
                        Name = "Bow"
                    }
                );

        }

    }
}
