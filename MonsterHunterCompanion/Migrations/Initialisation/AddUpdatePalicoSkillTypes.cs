using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace MonsterHunterCompanion.Migrations.Initialisation
{
    public class AddUpdatePalicoSkillTypes
    {
        public static void AddOrUpdate(MonsterHunterCompanionDBContext context)
        {
            context.PalicoSkillTypes.AddOrUpdate(x => x.Name,
                new SkillType() { Name = "Passive" },
                new SkillType() { Name = "Support" });
        }
    }
}