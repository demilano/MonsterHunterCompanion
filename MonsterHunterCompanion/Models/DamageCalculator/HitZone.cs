using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    public class HitZone
    {
        public int HitzoneId { get; set; }

        public RawDamageModifier RawDamageModifier { 
            get 
            {
                return new RawDamageModifier()
                {
                    PercentageModifier = RawValue
                };
            }
        }

        // This is what you'd see on kirakano. It's actually a percentage modifier. We will obtain it via the damage modifier * 100, and ignore in database
        // Added for clarity though, even if it's the same
        // ignore
        public int RawValue { get; set; }

        // This should actually be a list of elemental weakness
        public IEnumerable<ElementDamageModifier> ElementDamageModifiers { get; set; }

        public virtual Monster Monster { get; set; } // Lazy loading do this?
    }
}