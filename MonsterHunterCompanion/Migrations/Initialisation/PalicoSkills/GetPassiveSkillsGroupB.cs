using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation.PalicoSkills
{
    public class GetPassiveSkillsGroupB
    {
        public static PalicoSkill[] Get(int skillGroupId, int skillTypeId)
        {
            var skills = new PalicoSkill[]
            {
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Attack Up L", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Critical Up L", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Defense Up L", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Health Up L", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Nine Lives (Attack)", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Guard L", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Knockout King", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Earplugs", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Negate Stun", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Counter Boost", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Support Boost", SkillTypeId = skillTypeId}
            };

            return skills;
        }
    }
}