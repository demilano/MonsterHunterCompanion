using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow
{
    [Table("Bows")]
    public class Bow : Weapon
    {
        public virtual ICollection<Charge> Charges { get; set; } // From 1 to 4
    }
}