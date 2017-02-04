using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using MonsterHunterCompanion.Models;

namespace MonsterHunterCompanion.Migrations.Initialisation
{
    public class AddUpdatePalicoSkillGroups
    {
        public static void AddOrUpdate(MonsterHunterCompanionDBContext context)
        {
            context.PalicoSkillGroups.AddOrUpdate(x => x.Group,
                new SkillGroup() { Group = "A", Cost = 3, GroupDescription = "Optional skill" },
                new SkillGroup() { Group = "B", Cost = 2, GroupDescription = "Optional skill" },
                new SkillGroup() { Group = "C", Cost = 1, GroupDescription = "Optional skill" },
                new SkillGroup() { Group = "D", Cost = 0, GroupDescription = "DLC skill" },
                new SkillGroup() { Group = "P", Cost = 0, GroupDescription = "Primary bias skill" },
                new SkillGroup() { Group = "S", Cost = 0, GroupDescription = "Secondary bias skill" },
                new SkillGroup() { Group = "M", Cost = 0, GroupDescription = "Mandatory skill" }
                );
        }
    }
}