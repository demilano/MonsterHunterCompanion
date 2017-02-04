using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation.PalicoSkills
{
    public class GetPassiveSkillsGroupA
    {
        public static PalicoSkill[] Get(int skillGroupId, int skillTypeId)
        {
            var skills = new PalicoSkill[]
            {           
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Element Attack Up", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Status Attack Up", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Anger Prone", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Revival Pro", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Omniresistance", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Support Priority", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Support Move +1", SkillTypeId = skillTypeId}
            };

            return skills;
        }
    }
}