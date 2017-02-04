using BowCompanion.Models.DamageCalculator.Weapons.ProwlerWeapon;
using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.DamageCalculator
{
    public class Weapon
    {
        public int WeaponId { get; set; }

        public string Name { get; set; }

        // Hone will affect DisplayRaw
        [NotMapped]
        public WeaponHone Hone { get; set; }

        // I.e, multiplier (divider) on displayed value. For bow, Displayed Value/1.2
        public WeaponType WeaponType { get; set; }

        // This is what is displayed for weapon damage without any modifiers
        public int DisplayRaw { get; set; }

        // This is what is displayed for element damage without any modifiers
        public int DisplayElementDamage { get; set; }

        // The element used (add awaken later)
        public Element Element { get; set; }

        // This is what is displayed for affinity without any modifiers
        public int DisplayAffinity { get; set; }

        [NotMapped]
        public RawDamageModifier RawDamageModifier
        {
            get
            {
                return new RawDamageModifier()
                {
                    BaseModifier = (int)(DisplayRaw / WeaponType.Factor),
                    PercentageAffinity = DisplayAffinity
                };
            }
        }

        [NotMapped]
        public int ElementDamage
        {
            get
            {
                return DisplayElementDamage / 10;
            }
        }
    }
}