using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow
{
    public class Charge
    {
        public int ChargeId { get; set; } // A fair few combinations

        public int ShotId { get; set; }

        [ForeignKey("ChargeLevel")]
        public int Level { get; set; }

        public virtual ChargeLevel ChargeLevel { get; set; } // 1 - 4

        public virtual Shot Shot { get; set; } // 1 - 5 and shot type

        public virtual ICollection<Bow> Bows { get; set; } // Many to Many mapping
    }
}