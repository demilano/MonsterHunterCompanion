using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Migrations.Initialisation.VillageProbabilities
{
    public class GetBhernaVillageProbabilities
    {
        public static Dictionary<string, decimal> Get()
        {
            var probabilities = new Dictionary<string, decimal>();
            //Support
            //A 
            probabilities.Add("Health Horn", 0.15M);
            probabilities.Add("Giga Barrel Bombay", 0.15M);
            probabilities.Add("Anti-Monster Mine+", 0.15M);
            probabilities.Add("Pitfall Purr-ison", 0.15M);
            probabilities.Add("Shock Purr-ison", 0.15M);
            probabilities.Add("Pilfer", 0.10M);
            probabilities.Add("Rath-of-Meow", 0.15M);

            probabilities.Add("Detox Horn", 0.10M);
            probabilities.Add("Big Barrel Bombay", 0.10M);
            probabilities.Add("Flash Bombay", 0.10M);
            probabilities.Add("Anti-Monster Mine", 0.10M);
            probabilities.Add("Trampoliner", 0.10M);
            probabilities.Add("Vase of Vitality", 0.10M);
            probabilities.Add("Weapon Upgrade", 0.10M);
            probabilities.Add("Go, Fight, Win", 0.10M);
            probabilities.Add("Claw Dance", 0.10M);
            probabilities.Add("Mega Boomerang", 0.10M);

            //C
            probabilities.Add("Ultrasonic Horn", 0.08M);
            probabilities.Add("Barrel Bombay", 0.08M);
            probabilities.Add("Bounce Bombay", 0.07M);
            probabilities.Add("Parting Gift", 0.08M);
            probabilities.Add("Big Boomerang", 0.08M);
            probabilities.Add("Dung Bombay", 0.07M);
            probabilities.Add("Soothing Roll", 0.08M);
            probabilities.Add("Explosive Roll", 0.07M);
            probabilities.Add("Felyne Comet", 0.08M);
            probabilities.Add("Sumo Stomp", 0.08M);
            probabilities.Add("Chestnut Cannon", 0.08M);
            probabilities.Add("Shock Tripper", 0.08M);
            probabilities.Add("Excavator", 0.07M);

            // Passive
            // A
            probabilities.Add("Omniresistance", 0.15M);
            probabilities.Add("Element Attack Up", 0.15M);
            probabilities.Add("Status Attack Up", 0.10M);
            probabilities.Add("Support Priority", 0.15M);
            probabilities.Add("Support Move +1", 0.15M);
            probabilities.Add("Revival Pro", 0.15M);
            probabilities.Add("Anger Prone", 0.15M);

            // B
            probabilities.Add("Health Up L", 0.10M);
            probabilities.Add("Attack Up L", 0.10M);
            probabilities.Add("Defense Up L", 0.10M);
            probabilities.Add("Critical Up L", 0.08M);
            probabilities.Add("Knockout King", 0.08M);
            probabilities.Add("Guard L", 0.10M);
            probabilities.Add("Support Boost", 0.10M);
            probabilities.Add("Negate Stun", 0.08M);
            probabilities.Add("Earplugs", 0.08M);
            probabilities.Add("Nine Lives (Attack)", 0.08M);
            probabilities.Add("Counter Boost", 0.10M);

            // C
            probabilities.Add("Health Up S", 0.08M);
            probabilities.Add("Critical Up S", 0.06M);
            probabilities.Add("Stamina Drain", 0.06M);
            probabilities.Add("Negate Poison", 0.08M);
            probabilities.Add("Negate Wind", 0.08M);
            probabilities.Add("Negate Paralysis", 0.06M);
            probabilities.Add("Negate Confusion", 0.08M);
            probabilities.Add("Tremor Res", 0.06M);
            probabilities.Add("Negate Sleep", 0.06M);
            probabilities.Add("Biology", 0.06M);
            probabilities.Add("Iron Hide", 0.06M);
            probabilities.Add("Non-Stick Fur", 0.06M);
            probabilities.Add("Nine Lives (Defense)", 0.06M);
            probabilities.Add("Boomerang Pro", 0.06M);
            probabilities.Add("Goldenfish Catcher", 0.08M);

            return probabilities;
        }
    }
}