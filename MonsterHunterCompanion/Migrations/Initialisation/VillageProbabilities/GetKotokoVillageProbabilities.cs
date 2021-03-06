﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation.VillageProbabilities
{
    public class GetKotokoVillageProbabilities
    {
        public static Dictionary<string, decimal> Get()
        {
            var probabilities = new Dictionary<string, decimal>();
            //Support
            //A 
            probabilities.Add("Health Horn", 0.10M);
            probabilities.Add("Giga Barrel Bombay", 0.25M);
            probabilities.Add("Anti-Monster Mine+", 0.25M);
            probabilities.Add("Pitfall Purr-ison", 0.05M);
            probabilities.Add("Shock Purr-ison", 0.05M);
            probabilities.Add("Pilfer", 0.05M);
            probabilities.Add("Rath-of-Meow", 0.25M);

            probabilities.Add("Detox Horn", 0.04M);
            probabilities.Add("Big Barrel Bombay", 0.18M);
            probabilities.Add("Flash Bombay", 0.04M);
            probabilities.Add("Anti-Monster Mine", 0.18M);
            probabilities.Add("Trampoliner", 0.04M);
            probabilities.Add("Vase of Vitality", 0.04M);
            probabilities.Add("Weapon Upgrade", 0.13M);
            probabilities.Add("Go, Fight, Win", 0.04M);
            probabilities.Add("Claw Dance", 0.18M);
            probabilities.Add("Mega Boomerang", 0.13M);

            //C
            probabilities.Add("Ultrasonic Horn", 0.04M);
            probabilities.Add("Barrel Bombay", 0.1M);
            probabilities.Add("Bounce Bombay", 0.1M);
            probabilities.Add("Parting Gift", 0.04M);
            probabilities.Add("Big Boomerang", 0.1M);
            probabilities.Add("Dung Bombay", 0.04M);
            probabilities.Add("Soothing Roll", 0.04M);
            probabilities.Add("Explosive Roll", 0.1M);
            probabilities.Add("Felyne Comet", 0.1M);
            probabilities.Add("Sumo Stomp", 0.1M);
            probabilities.Add("Chestnut Cannon", 0.1M);
            probabilities.Add("Shock Tripper", 0.04M);
            probabilities.Add("Excavator", 0.1M);

            // Passive
            // A
            probabilities.Add("Omniresistance", 0.05M);
            probabilities.Add("Element Attack Up", 0.25M);
            probabilities.Add("Status Attack Up", 0.25M);
            probabilities.Add("Support Priority", 0.05M);
            probabilities.Add("Support Move +1", 0.10M);
            probabilities.Add("Revival Pro", 0.05M);
            probabilities.Add("Anger Prone", 0.25M);

            // B
            probabilities.Add("Health Up L", 0.05M);
            probabilities.Add("Attack Up L", 0.20M);
            probabilities.Add("Defense Up L", 0.05M);
            probabilities.Add("Critical Up L", 0.15M);
            probabilities.Add("Knockout King", 0.05M);
            probabilities.Add("Guard L", 0.05M);
            probabilities.Add("Support Boost", 0.05M);
            probabilities.Add("Negate Stun", 0.05M);
            probabilities.Add("Earplugs", 0.05M);
            probabilities.Add("Nine Lives (Attack)", 0.15M);
            probabilities.Add("Counter Boost", 0.15M);

            // C
            probabilities.Add("Health Up S", 0.06M);
            probabilities.Add("Critical Up S", 0.20M);
            probabilities.Add("Stamina Drain", 0.15M);
            probabilities.Add("Negate Poison", 0.04M);
            probabilities.Add("Negate Wind", 0.04M);
            probabilities.Add("Negate Paralysis", 0.04M);
            probabilities.Add("Negate Confusion", 0.04M);
            probabilities.Add("Tremor Res", 0.04M);
            probabilities.Add("Negate Sleep", 0.04M);
            probabilities.Add("Biology", 0.04M);
            probabilities.Add("Iron Hide", 0.04M);
            probabilities.Add("Non-Stick Fur", 0.04M);
            probabilities.Add("Nine Lives (Defense)", 0.04M);
            probabilities.Add("Boomerang Pro", 0.15M);
            probabilities.Add("Goldenfish Catcher", 0.04M);

            return probabilities;
        }
    }
}