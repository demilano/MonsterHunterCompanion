using MonsterHunterCompanion.Models.DamageCalculator;
using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.BowDamageCalculator.Interfaces
{
    public interface IRawDamageCalculator
    {
        decimal CalculateDamage(BowAttack attack);
    }
}