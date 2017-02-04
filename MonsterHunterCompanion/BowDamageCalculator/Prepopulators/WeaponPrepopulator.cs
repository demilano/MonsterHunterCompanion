using MonsterHunterCompanion.Models.DamageCalculator;
using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowCompanion.BowDamageCalculator.Prepopulators
{
    public class WeaponPrepopulator
    {
        public static Bow GetUkanlosSkyFlier()
        {
            return new Bow()
            {
                Name = "UkanlosSkyFlier",
                DisplayRaw = 444,
                DisplayElementDamage = 100,
                Element = MonsterHunterCompanion.Models.DamageCalculator.Element.ICE,
                WeaponType = new WeaponType()
                {
                    Factor = 1.2M,
                    Name = "Bow"
                },
                Hone = new WeaponHone()
                {
                    RawDamageModifier = new RawDamageModifier()
                    {
                        BaseModifier = 20,
                        Group = 0
                    }
                },
                Charges = new List<Charge>()
                {
                    new Charge()
                    {
                        ChargeLevel = new ChargeLevel()
                        {
                            Level = 4,
                            RawDecimalModifier = 1.7M,
                            ElementDecimalModifier = 1.125M
                        },
                        Shot = new Shot()
                        {
                            ShotLevel = 5,
                            MotionValuePercentage = 22,
                            NumberOfArrows = 3,
                            ShotType = ShotType.NORMAL_RAPID
                        }
                    }
                },
                DisplayAffinity = -30
            };
        }
    }
}