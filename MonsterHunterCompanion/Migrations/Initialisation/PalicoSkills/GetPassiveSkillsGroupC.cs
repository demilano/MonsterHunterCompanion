using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation.PalicoSkills
{
    public class GetPassiveSkillsGroupC
    {
        public static PalicoSkill[] Get(int skillGroupId, int skillTypeId)
        {
            var skills = new PalicoSkill[]
            {
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Critical Up S", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Health Up S", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Nine Lives (Defense)", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Boomerang Pro", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Stamina Drain", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Non-Stick Fur", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Negate Wind", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Negate Sleep", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Iron Hide", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Negate Paralysis", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Tremor Res", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Negate Poison", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Biology", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Negate Confusion", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Goldenfish Catcher", SkillTypeId = skillTypeId}
            };

            return skills;
        }
    }
}