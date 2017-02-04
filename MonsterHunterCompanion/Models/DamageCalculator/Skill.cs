using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    public class Skill
    {
        public int SkillId { get; set; }

        public string SkillName { get; set; }

        // This is for Ruthlessness and Weakness exploit
        // Need to pass in the monster's targetted hit zone
        public int RequiredHitZone { get; set; }

        public ShotType RequiredShotType { get; set; } 

        public virtual RawDamageModifier RawDamageModifier { get; set; }

        public virtual ElementDamageModifier ElementDamageModifier { get; set; }
    }
}