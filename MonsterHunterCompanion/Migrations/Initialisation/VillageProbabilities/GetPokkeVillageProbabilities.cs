using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation.VillageProbabilities
{
    public class GetPokkeVillageProbabilities
    {
        public static Dictionary<string, decimal> Get()
        {
            var probabilities = new Dictionary<string, decimal>();
            //Support
            //A 
            probabilities.Add("Health Horn", 0.50M);
            probabilities.Add("Giga Barrel Bombay", 0.05M);
            probabilities.Add("Anti-Monster Mine+", 0.05M);
            probabilities.Add("Pitfall Purr-ison", 0.15M);
            probabilities.Add("Shock Purr-ison", 0.15M);
            probabilities.Add("Pilfer", 0.05M);
            probabilities.Add("Rath-of-Meow", 0.05M);

            probabilities.Add("Detox Horn", 0.30M);
            probabilities.Add("Big Barrel Bombay", 0.03M);
            probabilities.Add("Flash Bombay", 0.05M);
            probabilities.Add("Anti-Monster Mine", 0.03M);
            probabilities.Add("Trampoliner", 0.10M);
            probabilities.Add("Vase of Vitality", 0.30M);
            probabilities.Add("Weapon Upgrade", 0.03M);
            probabilities.Add("Go, Fight, Win", 0.10M);
            probabilities.Add("Claw Dance", 0.03M);
            probabilities.Add("Mega Boomerang", 0.03M);

            //C
            probabilities.Add("Ultrasonic Horn", 0.10M);
            probabilities.Add("Barrel Bombay", 0.04M);
            probabilities.Add("Bounce Bombay", 0.04M);
            probabilities.Add("Parting Gift", 0.24M);
            probabilities.Add("Big Boomerang", 0.04M);
            probabilities.Add("Dung Bombay", 0.15M);
            probabilities.Add("Soothing Roll", 0.15M);
            probabilities.Add("Explosive Roll", 0.04M);
            probabilities.Add("Felyne Comet", 0.04M);
            probabilities.Add("Sumo Stomp", 0.04M);
            probabilities.Add("Chestnut Cannon", 0.04M);
            probabilities.Add("Shock Tripper", 0.04M);
            probabilities.Add("Excavator", 0.04M);

            // Passive
            // A
            probabilities.Add("Omniresistance", 0.25M);
            probabilities.Add("Element Attack Up", 0.05M);
            probabilities.Add("Status Attack Up", 0.05M);
            probabilities.Add("Support Priority", 0.15M);
            probabilities.Add("Support Move +1", 0.15M);
            probabilities.Add("Revival Pro", 0.30M);
            probabilities.Add("Anger Prone", 0.05M);

            // B
            probabilities.Add("Health Up L", 0.20M);
            probabilities.Add("Attack Up L", 0.05M);
            probabilities.Add("Defense Up L", 0.25M);
            probabilities.Add("Critical Up L", 0.05M);
            probabilities.Add("Knockout King", 0.05M);
            probabilities.Add("Guard L", 0.05M);
            probabilities.Add("Support Boost", 0.05M);
            probabilities.Add("Negate Stun", 0.15M);
            probabilities.Add("Earplugs", 0.10M);
            probabilities.Add("Nine Lives (Attack)", 0.05M);
            probabilities.Add("Counter Boost", 0.05M);

            // C
            probabilities.Add("Health Up S", 0.08M);
            probabilities.Add("Critical Up S", 0.03M);
            probabilities.Add("Stamina Drain", 0.03M);
            probabilities.Add("Negate Poison", 0.08M);
            probabilities.Add("Negate Wind", 0.08M);
            probabilities.Add("Negate Paralysis", 0.08M);
            probabilities.Add("Negate Confusion", 0.08M);
            probabilities.Add("Tremor Res", 0.08M);
            probabilities.Add("Negate Sleep", 0.08M);
            probabilities.Add("Biology", 0.08M);
            probabilities.Add("Iron Hide", 0.08M);
            probabilities.Add("Non-Stick Fur", 0.08M);
            probabilities.Add("Nine Lives (Defense)", 0.08M);
            probabilities.Add("Boomerang Pro", 0.03M);
            probabilities.Add("Goldenfish Catcher", 0.03M);

            return probabilities;
        }
    }
}