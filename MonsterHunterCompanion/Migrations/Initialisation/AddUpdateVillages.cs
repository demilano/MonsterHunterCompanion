using MonsterHunterCompanion.Migrations;
using MonsterHunterCompanion.Migrations.Initialisation;
using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.Models.DamageCalculator;
using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using MonsterHunterCompanion.Models.Palico;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MonsterHunterCompanion.Migrations.Initialisation
{
    public class AddUpdateVillages
    {
        public static void AddOrUpdate(MonsterHunterCompanionDBContext context)
        {
            context.Villages.AddOrUpdate(x => x.Name,
                new Village() { Name = "Bherna" },
                new Village() { Name = "Kokoto" },
                new Village() { Name = "Pokke" },
                new Village() { Name = "Yukumo" }
                );
        }
    }
}