using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow
{
    public class Distance
    {
        // Enum, near close far
        // A bow will have a critical distance
        public int DistanceId { get; set; }

        public string Name { get; set;} // Very Close(0.8), Close, etc

        public virtual RawDamageModifier RawDamageModifier { get; set; }
    }

}