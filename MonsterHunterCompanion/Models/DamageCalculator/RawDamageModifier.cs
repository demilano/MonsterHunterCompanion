using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    public class RawDamageModifier
    {
        public int RawDamageModifierId { get; set; }

        public int Group { get; set; } // The higest overrides, except group J (10) which works on a priority system

        // Only for weakness exploit/ruthlessness. Add 5 to the hitzone
        public int HitzoneModifier { get; set; }

        public decimal PercentageHitzoneModifier
        {
            get
            {
                return HitzoneModifier / 100;
            }
        }

        // True raw/element additive. I.e, PowerCharm is +6 to base, so will be trueRaw + 6
        public int BaseModifier { get; set; }

        // I.e, 3rd charge gives a percentage modifier of 150%, so total damage x 1.5
        public int PercentageModifier { get; set; }

        //Db ignore
        public decimal DecimalModifier
        {
            get
            {
                return PercentageModifier / 100.0M;
            }
        }

        // Displayed affinity
        public int PercentageAffinity { get; set; }

        // decimal form of percentage increase, i.e, 30% additional critrate = 0.3
        public decimal DecimalAffinity
        {
            get
            {
                return PercentageAffinity / 100.0M;
            }
        }
    }
}