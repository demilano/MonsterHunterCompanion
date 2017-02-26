using MonsterHunterCompanion.PalicoProbabilityFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.PalicoProbabilityFinder
{
    public class TreeProbabilityCalculator : ITreeProbabilityCalculator
    {
        /// <summary>
        ///  This uses a tree structure to find and sum every branch that terminates with the successful probability
        ///  I.e, if checking for one value, it'll find the probability of every branch of a probability tree where that value was selected
        ///  For multiple values, it'll choose every branch where both values were selected (up to the maximum iteration, which counts down)
        ///  This particular function allows for non-uniform probability distributions
        /// </summary>
        /// <param name="iteration"> is three path iteration, i,e which branch it's up to <- - - etc, and it is our base function</param>
        /// <param name="villageProbability">VillageProbability is the one we're most interested in</param>
        /// <param name="remainingPool">Remaining pool is our remaining list of probabilities</param>
        /// <param name="givenValue">givenValue is our current givenValue to check</param>
        /// <param name="normaliser">Is 1 - the probability that the skill was already picked, since if picked we don't continue</param>
        /// <returns></returns>
        public decimal Calculate(int iteration, List<TreeProbabilityEntity> remainingPool, TreeProbabilityEntity givenValue, decimal givenProbabilityProduct)
        {
            var totalRemainingPool = remainingPool.Sum(x => x.Probability); // We don't need to remove the skill here since it's a conditional prob

            var skillPool = remainingPool.Where(x => x.Probability == givenValue.Probability).Sum(x => x.Probability); // Skil pool may be shared with our village probability
            decimal skillPoolCount = remainingPool.Where(x => x.Probability == givenValue.Probability).Count();
            decimal skillPoolMultiplier = givenValue.IsToBeCalculated ? 1M : remainingPool.Where(x => x.Probability == givenValue.Probability && !x.IsToBeCalculated).Count(); // Since we only care about our event, other probabilities are combined
/*
            if (totalRemainingPool == 0 || iteration == 0)
            {
                return 0; // Defensive, and if there's no instance of the skill group in the pool
            }*/

            // Conditional probaility of this value given the given value
            var conditionalProbability = (givenValue.IsToBeCalculated && skillPoolCount == 0) ? 1M : ((skillPool / totalRemainingPool) * (skillPoolMultiplier / skillPoolCount));// * probabilityOfGiven);

            //remainingPool.Remove(remainingPool.First(x => x.IsToBeCalculated == givenValue.IsToBeCalculated && x.Probability == givenValue.Probability)); // Remove the given value from pool. In effect removes it from skillPool if necessary
            remainingPool.Remove(givenValue);
            // Change this to check if there are any of the skill remaining (if only optionals are remaining and we last chose an optional, also terminate)
            if (!remainingPool.Any(x => x.IsToBeCalculated) || (!remainingPool.Any(x => x.IsToBeCalculated && !x.IsAnOptionalRequirement) && givenValue.IsAnOptionalRequirement)) // Strange way to do it but okay. Depth 1, this will return on the first. For the others, we are calculating conditional probability product
            {
                return givenProbabilityProduct * conditionalProbability;
            }
            else if (iteration <= 1)
            {
                return 0;
            }
            /*
            if (iteration == 1)
            {
                return 0; // So we should just return 0 (we didn't get it by this point, it's a failure
            }
            */
            givenProbabilityProduct = givenProbabilityProduct * conditionalProbability;

            var distinctProbabilities = remainingPool.Distinct();
            return distinctProbabilities.Sum(x => Calculate(iteration - 1, remainingPool.Select(y => new TreeProbabilityEntity() { IsAnOptionalRequirement = y.IsAnOptionalRequirement, IsToBeCalculated = y.IsToBeCalculated, Probability = y.Probability, UniqueId = y.UniqueId }).ToList(),
                x, givenProbabilityProduct));
        }
    }
}