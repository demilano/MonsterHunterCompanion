using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    public class WeaponType
    {
        public int WeaponTypeId { get; set; }

        public string Name { get; set; }

        public decimal Factor { get; set; }
    }
}