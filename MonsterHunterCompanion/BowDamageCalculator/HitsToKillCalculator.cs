using MonsterHunterCompanion.Models.DamageCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonsterHunterCompanion.BowDamageCalculator.Interfaces;

namespace MonsterHunterCompanion.BowDamageCalculator
{
    public class HitsToKillCalculator : IHitsToKillCalculator
    {
        private readonly IElementDamageCalculator _elementDamageCalculator;
        
        private readonly IRawDamageCalculator _rawDamageCalculator;

        public HitsToKillCalculator()
        {
            _elementDamageCalculator = new ElementDamageCalculator();
            _rawDamageCalculator = new RawDamageCalculator();
        }
        // This will be removed, but will just be how to calculate overall bow for now. 
        public decimal CalculateDamage()
        {
            // We will know Monster Health
            // Hitzones selected
            // Weapon used
            // Skills used
            // Coatings etc
            // Element decay?

            return 0;
        }
    }
}