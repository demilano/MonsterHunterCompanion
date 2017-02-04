using BowCompanion.Models.Palico;
using BowCompanion.PalicoProbabilityFinder.Interfaces;
using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.PalicoProbabilityFinder;
using MonsterHunterCompanion.PalicoProbabilityFinder.Interfaces;
using MonsterHunterCompanionOh.PalicoProbabilityFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowCompanion.PalicoProbabilityFinder
{
    public class PalicoProbabilityQueryHandler : IPalicoProbabilityQueryHandler
    {
        private readonly ISkillPatternQueryHandler _skillPatternQueryHandler;

        private readonly IVillageProbabilityQueryHandler _villageProbabilityQueryHandler;

        public PalicoProbabilityQueryHandler()
        {
            _skillPatternQueryHandler = new SkillPatternQueryHandler();
            _villageProbabilityQueryHandler = new VillageProbabilityQueryHandler();
        }

        // To test, have a pattern of 13 of one group. It should equal one
        // To test multiple skills, I think I can just multiple them? 
        public decimal FindProbability(PalicoProbabilityQuery query)
        {
            // Will just consolidate everything here
            // First, we assess the givens
            // As an example, we use my Palico, which (I believe) was found in Kotoko (will do passive later)
            /* Kotoko, Fighter, 
             * 1. Furrocious, 
             * 2 Piercing
             * 3. Mini Barrel
             * 4. Herb Horn
             * 5. Barrel Bombay
             * 6. Bounce Bombay
             * 7. Chestnut Cannon
             * 8. Sumo Stomp
             * 9. Soothing Roll
             * 10. Excavator
             * 11. Big Boomerangs
             * 12. Parting Gift
             * FREE: Emergency Retreat
            */
            /* Given: Fighter Bias (chosen)
             * Kotoko (chosen)
             * 1. Furrocious (given)
             * 2. 
             * 3. Mini Barrel (given)
             * 4. Herb Horn (given)
             * 5. ??
             */
            // So far, chance of Kotoko Furrocious Figher is %100
            decimal totalProbabilitySoFar = 1;
            // Now, probability that the palico will have P(Piercing | Kotoko,Furrocious,Fighter)
            // = P(Piercing | Fighter) = 0.5 (others are independent, 2 skills to choose from) 
            totalProbabilitySoFar = totalProbabilitySoFar * 0.5M; // Will be a supplied chosen skill, so we pass this to another handler. Won't choose for charisma
            // Now, the probabilty stays the same for the other givens, 3 and 4.
            // So now we go for our (second) choice, Big Boomerangs. Except we don't, we need to first apply validations
            ValidateQuery(query); // Query containing a list of skills.
            var supportSkills = query.SupportSkills.OrderBy(x => x.SkillGroup.Group); // Need to order it by group 
            var previousSkillGroup = supportSkills.FirstOrDefault().SkillGroup;

            /**
             * Firstly, support skills
             **/
            var skillProbabilities = new Dictionary<int, decimal>(); // Could be int decimal
            var skillPatterns = _skillPatternQueryHandler.GetSkillPatterns(query.Bias);
            var villageProbabilities = _villageProbabilityQueryHandler.VillageProbabilities(query.Village);

            // Change this to skill group iteration? Distinct skill group by support skills
            foreach (var skill in supportSkills)
            {
                //previousSkillGroup = skill.SkillGroup;
                var villageSkillProbability = villageProbabilities.FirstOrDefault(x => x.PalicoSkill.PalicoSkillId == skill.PalicoSkillId).Probability;

                foreach (var pattern in skillPatterns)
                {
                    // i.e, number of times the desired skill group appears. If 0, prob for that pattern is 0
                    // for 1, the probability is the village probability
                    // for over 1, we need to use conditional probability
                    int groupCount = pattern.SkillPatternList.Count(y => y.SkillGroup.Group.Equals(skill.SkillGroup.Group)); // Depth of tree
                    var initialPool = villageProbabilities.Select(x => x.Probability).ToList(); // This is all of the village probabilities, which should initially sum to 1 (100%)

                    // We need to identify one of the pool as ours, so we will make it negative
                    initialPool.Remove(villageSkillProbability);
                    initialPool.Add(-villageSkillProbability);
                    // This first one should be a sum
                    var distinctProbabilities = initialPool.Distinct();
                    var patternSkillProbability = distinctProbabilities.Sum(x => RecursiveFunction(groupCount, villageSkillProbability, new List<decimal>(initialPool), x, 1)); // Probability of this skill in this pattern

                    if (skillProbabilities.ContainsKey(skill.PalicoSkillId))
                    {
                        skillProbabilities[skill.PalicoSkillId] += patternSkillProbability * 1 / skillPatterns.Count(); // probability of pattern
                    }
                    else
                    {
                        skillProbabilities.Add(skill.PalicoSkillId, patternSkillProbability * 1 / skillPatterns.Count());
                    }
                };

                totalProbabilitySoFar = totalProbabilitySoFar * skillProbabilities[skill.PalicoSkillId];

                /* Groups are:
                    G1 A, B, B, B * (charisma only)
                    G2 A, B, B, C
                    G3 A, B, C, C, C
                    G4 A, C, C, C, C, C
                    G5 B, B, B, B
                    G6 B, B, B, C, C
                    G7 B, B, C, C, C, C
                    G8 C, C, C, C, C, C, C, C **
                 */


            };

            // 5 cats per village
            // Probability of at least 1 cat with the right moves
            // it's just
            var probabilityOfNotCorrectCat = 1 - totalProbabilitySoFar;

            totalProbabilitySoFar = 1 - (probabilityOfNotCorrectCat * probabilityOfNotCorrectCat * probabilityOfNotCorrectCat * probabilityOfNotCorrectCat * probabilityOfNotCorrectCat); // 5 cats

            return totalProbabilitySoFar;
        }


        public decimal Factorial(decimal number)
        {
            if (number == 0)
            {
                return 0;
            }
            else
            {
                return number * (number - 1);
            }
        }

        /// <summary>
        ///    
        /// </summary>
        /// <param name="iteration"> is three path iteration, i,e which branch it's up to <- - - etc, and it is our base function</param>
        /// <param name="villageProbability">VillageProbability is the one we're most interested in</param>
        /// <param name="remainingPool">Remaining pool is our remaining list of probabilities</param>
        /// <param name="givenValue">givenValue is our current givenValue to check</param>
        /// <param name="normaliser">Is 1 - the probability that the skill was already picked, since if picked we don't continue</param>
        /// <returns></returns>
        private decimal RecursiveFunction(int iteration, decimal villageProbability, List<decimal> remainingPool, decimal givenValue, decimal givenProbabilityProduct)
        {
            var totalRemainingPool = remainingPool.Sum(x => Math.Abs(x)); // We don't need to remove the skill here since it's a conditional prob

            var skillPool = remainingPool.Where(x => Math.Abs(x) == Math.Abs(givenValue)).Sum(x => Math.Abs(x)); // Skil pool may be shared with our village probability
            decimal skillPoolCount = remainingPool.Where(x => Math.Abs(x) == Math.Abs(givenValue)).Count();
            decimal skillPoolMultiplier = givenValue < 0 ? 1 : skillPoolCount; // Since we only care about our event, other probabilities are combined

            if (givenValue == villageProbability)
            {
                skillPoolMultiplier--;
            };

            if (totalRemainingPool == 0 || iteration == 0)
            {
                return 0; // Defensive, and if there's no instance of the skill group in the pool
            }

            var conditionalProbability = (givenValue < 0 && skillPoolCount == 0) ? 1 : ((skillPool / totalRemainingPool) * (skillPoolMultiplier / skillPoolCount));// * probabilityOfGiven);

            if (givenValue < 0) // Strange way to do it but okay. Depth 1, this will return on the first. For the others, we are calculating conditional probability product
            {
                System.Diagnostics.Debug.WriteLine("Final Probability Product: {0} on iteration {1} with given {2}. conditional is {3}", givenProbabilityProduct * conditionalProbability, iteration, givenValue, conditionalProbability);

                return givenProbabilityProduct * conditionalProbability;
            }

            remainingPool.Remove(givenValue); // Remove the given value from pool. In effect removes it from skillPool if necessary

            if (iteration == 1)
            {
                return 0; // So we should just return 0 (we didn't get it by this point, it's a failure
            }

            givenProbabilityProduct = givenProbabilityProduct * conditionalProbability;

            var distinctProbabilities = remainingPool.Distinct();
            return distinctProbabilities.Sum(x => RecursiveFunction(iteration - 1, villageProbability, new List<decimal>(remainingPool), x, givenProbabilityProduct));
        }

        // return (probability) + remainingPool.Distinct().Sum(x => RecursiveFunction(iteration - 1, villageProbability, remainingPoolToPass, x, 1 - probability, probOfGiven));

        private void ValidateQuery(PalicoProbabilityQuery query)
        {
            // If Score > maxScoreForBias, return false
            // If contains more than one A, return false
            // Skills are unique (I think that will be constrained on page anyway)
            // Other than that, it's fine
        }
    }
}