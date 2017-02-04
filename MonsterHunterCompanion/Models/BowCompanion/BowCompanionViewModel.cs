using MonsterHunterCompanion.Models.DamageCalculator;
using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowCompanion.Models.BowCompanion
{
    public class BowCompanionViewModel
    {
        // Contains the lst of weapons
        public IEnumerable<Bow> Bows { get; set; }

        // A weapon to add
        public Bow BowToAdd { get; set; }
        // Might change to non-dom weapon

        // Charges to select
        public IEnumerable<Charge> Charges { get; set; }

    }
}