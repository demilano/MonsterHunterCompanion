using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    public class Monster
    {
        public int MonsterId { get; set; }

        public string Name { get; set; }

        public IEnumerable<HitZone> HitZones { get; set; }


    }
}