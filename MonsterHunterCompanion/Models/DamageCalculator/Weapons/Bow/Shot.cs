using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow
{
    public class Shot
    {
        public int ShotId { get; set; }

        public int ShotLevel { get; set; } // Is level 1 to 5, NOT to be confused with charge level

        public int NumberOfArrows { get; set; }

        public ShotType ShotType { get; set; }

        public int MotionValuePercentage { get; set; } // This is the total motion value for the attack. We won't worry about multiple parts for now

        [NotMapped]
        public decimal MotionValueDecimal
        {
            get
            {
                return MotionValuePercentage / 100.0M;
            }
        }
    }
}