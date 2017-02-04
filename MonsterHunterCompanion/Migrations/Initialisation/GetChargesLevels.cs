using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation
{
    public class GetChargesLevels
    {
          public static ChargeLevel[] Get()
          {

              var charges = new ChargeLevel[]
              {
                  new ChargeLevel()
                  {
                      Level = 4,
                      RawDecimalModifier = 1.7M,
                      ElementDecimalModifier = 1.125M
                  },
                  new ChargeLevel()
                  {
                      Level = 3,
                      RawDecimalModifier = 1.5M,
                      ElementDecimalModifier = 1M
                  },
                  new ChargeLevel()
                  {
                      Level = 2,
                      RawDecimalModifier = 1,
                      ElementDecimalModifier = 0.85M
                  },
                  new ChargeLevel()
                  {
                      Level = 1,
                      RawDecimalModifier = 0.4M,
                      ElementDecimalModifier = 0.7M
                  },
              };

              return charges;
          }
    }
}