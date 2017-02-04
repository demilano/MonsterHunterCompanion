using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    public class ElementDamageModifier
    {
        public int ElementDamageModifierId { get; set; }

        public Element Element { get; set; }

        // The displayed (kirakano or what not) vaue
        public int PercentageModifier { get; set; }

        //Db ignore
        public decimal DecimalModifier
        {
            get
            {
                return PercentageModifier / 100.0M;
            }
        }
    }
}