using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    public class GlobalModifier
    {
        public string Description { get; set; } // GRank, village, gathering hall, etc

        public decimal Multiplier { get; set; }
    }
}