using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    // Attack consists of:
    // Attack with what (weapon, skills, boosts)
    // Attack what and where (monster, hitzone)
    // Ignore from DB, or add for remembering combination?
    public class Attack
    {
        public IEnumerable<Item> Items { get; set; }

        public IEnumerable<Skill> Skills { get; set; }

        // Against What
        public HitZone HitZone { get; set; }

        public GlobalModifier GlobalModifier { get; set; }
    }
}