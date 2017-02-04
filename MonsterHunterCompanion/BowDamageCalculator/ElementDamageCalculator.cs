using MonsterHunterCompanion.Models.DamageCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using MonsterHunterCompanion.BowDamageCalculator.Interfaces;
using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;

namespace MonsterHunterCompanion.BowDamageCalculator
{
    public class ElementDamageCalculator : IElementDamageCalculator
    {
        public decimal CalculateDamage(BowAttack attack)
        {
            // Fairly simple, just number of arrows x elem damage x hitzoneElementModifier for that element
            var charge = attack.Bow.Charges.FirstOrDefault(x => x.ChargeLevel.Level == attack.SelectedChargeLevel);
            var elementWeaknessModifier = attack.HitZone.ElementDamageModifiers.Any(x => x.Element == attack.Bow.Element) ?
                attack.HitZone.ElementDamageModifiers.FirstOrDefault(x => x.Element == attack.Bow.Element).DecimalModifier : 0;

            return charge.Shot.NumberOfArrows * charge.ChargeLevel.ElementDecimalModifier * attack.Bow.ElementDamage * elementWeaknessModifier;
        }
    }
}