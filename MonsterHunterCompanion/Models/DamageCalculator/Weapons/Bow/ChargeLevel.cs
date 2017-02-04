using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow
{
    public class ChargeLevel
    {
        [Key]
        public int Level { get; set; } // 1 to 4, primary key

        public decimal RawDecimalModifier { get; set; }

        public decimal ElementDecimalModifier { get; set; }

      //  protected virtual ICollection<Charge> Charges { get; set; }
    }
}