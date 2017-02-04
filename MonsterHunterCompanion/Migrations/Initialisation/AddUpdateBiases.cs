using MonsterHunterCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using MonsterHunterCompanion.Models.Palico;

namespace MonsterHunterCompanion.Migrations.Initialisation
{
    public class AddUpdateBiases
    {
        public static void AddOrUpdate(MonsterHunterCompanionDBContext context)
        {
            context.Biases.AddOrUpdate(x => x.Name,
                new Bias() { Name = "Charisma", MaxSkillCost = 9 },
                new Bias() { Name = "Fighting", MaxSkillCost = 8 },
                new Bias() { Name = "Protection", MaxSkillCost = 8 },
                new Bias() { Name = "Assisting", MaxSkillCost = 8 },
                new Bias() { Name = "Healing", MaxSkillCost = 8 },
                new Bias() { Name = "Bombing", MaxSkillCost = 8 },
                new Bias() { Name = "Gathering", MaxSkillCost = 8 },
                new Bias() { Name = "All", MaxSkillCost = 0 }); // Really not sure about having this as a bias
        }
    }
}