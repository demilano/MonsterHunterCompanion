using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    public class WeaponHone
    {
        public int WeaponHoneId { get; set; }

        public string Name { get; set; }

        public RawDamageModifier RawDamageModifier { get; set; }

        public virtual Weapon Weapon { get; set; }
    }
}