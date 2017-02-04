using MonsterHunterCompanion.Models.DamageCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using MonsterHunterCompanion.BowDamageCalculator.Interfaces;
using System.Diagnostics;
using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;

namespace MonsterHunterCompanion.BowDamageCalculator
{
    public class RawDamageCalculator :IRawDamageCalculator
    {
        // This will be removed, but will just be how to calculate overall bow for now. 
        public decimal CalculateDamage(BowAttack attack)
        {
            // Apply hitzone modifiers (ruth/weakness exploit)
            if (attack.Skills.Any(x => x.RawDamageModifier.HitzoneModifier > 0 && attack.HitZone.RawValue >= x.RequiredHitZone))
            {
                attack.HitZone.RawValue += attack.Skills.Where(x => x.RawDamageModifier.HitzoneModifier > 0 && attack.HitZone.RawValue >= x.RequiredHitZone).FirstOrDefault().RawDamageModifier.HitzoneModifier;
            }
            
            // Now take all damage modifiers, and sum their base increase to raw
            var trueRaw = GetTrueRaw(attack);

            // Then calculate Affinity
            var affinityMultiplier = GetAffinityMultiplier(attack);

            // This is for skills like Challenger that give a 1.5 or so percentage modifier
            var skillMultiplier = attack.Skills.Where(x => x.RawDamageModifier.DecimalModifier > 0).Aggregate(1.0M, (x, y) => x * y.RawDamageModifier.DecimalModifier); // Remeber to div by 100
            
            var coatingMultipler = attack.Coating != null ? attack.Coating.RawDamageModifier.DecimalModifier : 1;

            var charge = attack.Bow.Charges.First(x => attack.SelectedChargeLevel == x.ChargeLevel.Level);

            // So it will be
            var total = trueRaw * affinityMultiplier * skillMultiplier * charge.ChargeLevel.RawDecimalModifier
                * coatingMultipler * attack.Distance.RawDamageModifier.DecimalModifier * charge.Shot.MotionValueDecimal
                * attack.HitZone.RawDamageModifier.DecimalModifier * attack.GlobalModifier.Multiplier;
            
            return total;
        }

        private decimal GetTrueRaw(BowAttack attack)
        {
            var trueRaw = attack.Bow.RawDamageModifier.BaseModifier;

            var groups = (from item in attack.Items select item.RawDamageModifier.Group).Concat
                        (from skill in attack.Skills select skill.RawDamageModifier.Group).Concat
                        (new List<int>(attack.Bow.Hone.RawDamageModifier.Group)).Distinct().ToList(); 

            var damageModifiers = (from item in attack.Items select item.RawDamageModifier).Concat
                        (from skill in attack.Skills select skill.RawDamageModifier).ToList();
            damageModifiers.Add(attack.Bow.Hone.RawDamageModifier); // Gotta add that one too

            var totalRaw = from dmg in damageModifiers
                           group dmg by dmg.Group into grp
                           select new { Damage = grp.Max(x => x.BaseModifier) };

            trueRaw += totalRaw.Sum(x => x.Damage);

            return trueRaw;
        }

        private decimal GetAffinityMultiplier(BowAttack attack)
        {
            var totalAffinity = attack.Bow.RawDamageModifier.DecimalAffinity; // In decimal form 
            // Only other things that affect affinity is skills (expert, etc)
            totalAffinity += attack.Skills.Sum(x => x.RawDamageModifier.DecimalAffinity);

            return 1 + (0.25M * totalAffinity);
        }
    }
}