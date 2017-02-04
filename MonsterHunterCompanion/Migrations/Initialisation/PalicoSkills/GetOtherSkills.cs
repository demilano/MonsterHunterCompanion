using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation.PalicoSkills
{
    /// <summary>
    /// Bias specific and mandatory skills
    /// </summary>
    public class GetOtherSkills
    {
        public static PalicoSkill[] Get(List<Bias> biases, int passiveSkillTypeId, int supportSkillTypeId, List<SkillGroup> skillGroups)
        {
            var mandatorySkillGroupId = skillGroups.First(x => x.Group.Equals("M")).SkillGroupId;
            var primarySkillGroupId = skillGroups.First(x => x.Group.Equals("P")).SkillGroupId;
            var secondarySkillGroupId = skillGroups.First(x => x.Group.Equals("S")).SkillGroupId;
            // Worry about dlc later
            var skills = new PalicoSkill[]
            {       
                    // Primary
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Palico Rally", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Charisma")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Furr-ious", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Fighting")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Taunt", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Protection")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Poison Purr-ison", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Assisting")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "True Health Horn", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Healing")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Mega Barrel Bombay", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Bombing")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Plunderang", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Gathering")).BiasId },
                    // Secondary (none for charismas
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Demon Horn", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Fighting")).BiasId },
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Emergency Retreat", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Protection")).BiasId },
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Cheer Horn", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Assisting")).BiasId },
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Armor Horn", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Healing")).BiasId },
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Camouflage", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Bombing")).BiasId },
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Piercing Boomerang", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Gathering")).BiasId },
                    
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Piercing Boomerang", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Fighting")).BiasId },
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Armor Horn", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Protection")).BiasId },
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Emergency Retreat", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Assisting")).BiasId },
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Cheer Horn", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Healing")).BiasId },
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Demon Horn", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Bombing")).BiasId },
                    new PalicoSkill() { SkillGroupId = secondarySkillGroupId, Name = "Camouflage", SkillTypeId = supportSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Gathering")).BiasId },

                    // Mandatory support for all cats
                    new PalicoSkill() { SkillGroupId = mandatorySkillGroupId, Name = "Mini Barrel Bombay", SkillTypeId = supportSkillTypeId },
                    new PalicoSkill() { SkillGroupId = mandatorySkillGroupId, Name = "Herb Horn", SkillTypeId = supportSkillTypeId },

                    // 'Primary' passives, though they are also secondary I guess. Though primarys can't be taught to others
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Slacker Slap", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Charisma")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Attack Up S", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Fighting")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Guard S", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Protection")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Monsterdar", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Assisting")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Defense Up S", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Healing")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Heat/Bomb Res", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Bombing")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Gathering Pro", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Gathering")).BiasId },

                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Last Stand", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Charisma")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Handicraft", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Fighting")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Guard Boost", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Protection")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Pro Trapper", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Assisting")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Health Harmonics", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Healing")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Bombay Boost", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Bombing")).BiasId },
                    new PalicoSkill() { SkillGroupId = primarySkillGroupId, Name = "Pilfer Boost", SkillTypeId = passiveSkillTypeId, BiasId = biases.First(x => x.Name.Equals("Gathering")).BiasId }
            };

            return skills;
        }
    }
}