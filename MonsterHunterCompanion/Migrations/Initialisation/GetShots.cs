using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation
{
    public class GetShots
    {
        public static Shot[] Get()
        {
            // Rapid first 
            var chargeShots = new Shot[]
            {
                new Shot()
                {
                    ShotLevel = 1,
                    MotionValuePercentage = 12,
                    NumberOfArrows = 1,
                    ShotType = ShotType.NORMAL_RAPID
                },
                new Shot()
                {
                    ShotLevel = 2,
                    MotionValuePercentage = 16,
                    NumberOfArrows = 2,
                    ShotType = ShotType.NORMAL_RAPID
                },
                new Shot()
                {
                    ShotLevel = 3,
                    MotionValuePercentage = 19,
                    NumberOfArrows = 3,
                    ShotType = ShotType.NORMAL_RAPID
                },
                new Shot()
                {
                    ShotLevel = 4,
                    MotionValuePercentage = 21,
                    NumberOfArrows = 4,
                    ShotType = ShotType.NORMAL_RAPID
                },
                new Shot()
                {
                    ShotLevel = 5,
                    MotionValuePercentage = 22,
                    NumberOfArrows = 4,
                    ShotType = ShotType.NORMAL_RAPID
                }
            };

            return chargeShots;
        }
    }
}