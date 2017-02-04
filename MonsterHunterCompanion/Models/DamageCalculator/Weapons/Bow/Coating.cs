using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow
{
    public class Coating
    {
        public int CoatingId { get; set; }

        public string Name { get; set; }

        public virtual ElementDamageModifier ElementDamageModifier { get; set; }

        public virtual RawDamageModifier RawDamageModifier { get; set; }
    }
}