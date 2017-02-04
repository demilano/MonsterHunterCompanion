using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation.PalicoSkills
{
    public class GetSupportSkillsGroupB
    {
        public static PalicoSkill[] Get(int skillGroupId, int skillTypeId)
        {
            var skills = new PalicoSkill[]
            {
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Claw Dance", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Weapon Upgrade", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Trampoliner", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Go, Fight, Win", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Detox Horn", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Vase of Vitality", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Mega Boomerang", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Flash Bombay", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Big Barrel Bombay", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Anti-Monster Mine", SkillTypeId = skillTypeId}
            };

            return skills;
        }
    }
}