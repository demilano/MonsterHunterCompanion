using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using MonsterHunterCompanion.Migrations.Initialisation.PalicoSkills;

namespace MonsterHunterCompanion.Migrations.Initialisation
{
    public class AddUpdatePalicoSkills
    {
        internal static void AddOrUpdate(MonsterHunterCompanionDBContext context)
        {
            var skillGroups = context.PalicoSkillGroups.ToList();
            var aGroupId = skillGroups.FirstOrDefault(x => x.Group.Equals("A")).SkillGroupId;
            var bGroupId = skillGroups.FirstOrDefault(x => x.Group.Equals("B")).SkillGroupId;
            var cGroupId = skillGroups.FirstOrDefault(x => x.Group.Equals("C")).SkillGroupId;

            var passiveTypeId = context.PalicoSkillTypes.FirstOrDefault(x => x.Name.Equals("Passive")).SkillTypeId;
            var supportTypeId = context.PalicoSkillTypes.FirstOrDefault(x => x.Name.Equals("Support")).SkillTypeId;
            // Support Skills
            context.PalicoSkills.AddOrUpdate(x => x.Name,
                GetSupportSkillsGroupA.Get(aGroupId, supportTypeId)
            );

            context.PalicoSkills.AddOrUpdate(x => x.Name,
                GetSupportSkillsGroupB.Get(bGroupId, supportTypeId)
            );

            context.PalicoSkills.AddOrUpdate(x => x.Name,
                GetSupportSkillsGroupC.Get(cGroupId, supportTypeId)
            );

            // Passive Skills
            context.PalicoSkills.AddOrUpdate(x => x.Name,
                GetPassiveSkillsGroupA.Get(aGroupId, passiveTypeId)
            );

            context.PalicoSkills.AddOrUpdate(x => x.Name,
                GetPassiveSkillsGroupB.Get(bGroupId, passiveTypeId)
            );

            context.PalicoSkills.AddOrUpdate(x => x.Name,
                GetPassiveSkillsGroupC.Get(cGroupId, passiveTypeId)
            );

            // Add mandatory skills and class specific skills
            var existingSkills = context.PalicoSkills.ToList();

            // Not ideal, but best we can do at the moment
            foreach(var skill in GetOtherSkills.Get(context.Biases.ToList(), passiveTypeId, supportTypeId, skillGroups).ToList())
            {
                if(!existingSkills.Any(x => x.Name.Equals(skill.Name) && x.BiasId.GetValueOrDefault() == skill.BiasId.GetValueOrDefault()))
                {
                    context.PalicoSkills.Add(skill);
                }
            };
           // context.PalicoSkills.Add(GetOtherSkills.Get(context.Biases.ToList(), passiveTypeId, supportTypeId, skillGroups));
        }
    }
}