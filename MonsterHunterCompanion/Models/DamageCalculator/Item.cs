using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    public class Item
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public virtual RawDamageModifier RawDamageModifier { get; set; }

        // No item contains element damage modifier
    }
}