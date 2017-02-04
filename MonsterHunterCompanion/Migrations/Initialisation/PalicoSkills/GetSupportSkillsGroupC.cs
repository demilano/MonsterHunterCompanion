using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation.PalicoSkills
{
    public class GetSupportSkillsGroupC
    {
        public static PalicoSkill[] Get(int skillGroupId, int skillTypeId)
        {
            var skills = new PalicoSkill[]
            {
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Sumo Stomp", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Felyne Comet", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Dung Bombay", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Ultrasonic Horn", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Soothing Roll", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Parting Gift", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Excavator", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Big Boomerang", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Shock Tripper", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Chestnut Cannon", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Barrel Bombay", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Bounce Bombay", SkillTypeId = skillTypeId},
                    new PalicoSkill() { SkillGroupId = skillGroupId, Name = "Explosive Roll", SkillTypeId = skillTypeId}
            };

            return skills;
        }
    }
}