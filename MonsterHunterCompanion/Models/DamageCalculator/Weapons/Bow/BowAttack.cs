using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow
{
    public class BowAttack : Attack
    {
        public Bow Bow { get; set; }

        public int SelectedChargeLevel { get; set; }

        public Coating Coating { get; set; }

        public Distance Distance { get; set; }
    }
}