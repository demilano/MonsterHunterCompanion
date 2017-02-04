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
        public decimal Calculate(int iteration, List<decimal> remainingPool, decimal givenValue, decimal givenProbabilityProduct)
        {
            var totalRemainingPool = remainingPool.Sum(x => Math.Abs(x)); // We don't need to remove the skill here since it's a conditional prob

            var skillPool = remainingPool.Where(x => Math.Abs(x) == Math.Abs(givenValue)).Sum(x => Math.Abs(x)); // Skil pool may be shared with our village probability
            decimal skillPoolCount = remainingPool.Where(x => Math.Abs(x) == Math.Abs(givenValue)).Count();
            decimal skillPoolMultiplier = givenValue < 0 ? 1 : remainingPool.Where(x => x == givenValue).Count(); // Since we only care about our event, other probabilities are combined

            if (totalRemainingPool == 0 || iteration == 0)
            {
                return 0; // Defensive, and if there's no instance of the skill group in the pool
            }

            // Conditional probaility of this value given the given value
            var conditionalProbability = (givenValue < 0 && skillPoolCount == 0) ? 1 : ((skillPool / totalRemainingPool) * (skillPoolMultiplier / skillPoolCount));// * probabilityOfGiven);

            remainingPool.Remove(givenValue); // Remove the given value from pool. In effect removes it from skillPool if necessary

            // Change this to check if there are any of the skill remaining
            if (!remainingPool.Any(x => x < 0)) // Strange way to do it but okay. Depth 1, this will return on the first. For the others, we are calculating conditional probability product
            {
                // System.Diagnostics.Debug.WriteLine("Final Probability Product: {0} on iteration {1} with given {2}. conditional is {3}", givenProbabilityProduct * conditionalProbability, iteration, givenValue, conditionalProbability);

                return givenProbabilityProduct * conditionalProbability;
            }

            if (iteration == 1)
            {
                return 0; // So we should just return 0 (we didn't get it by this point, it's a failure
            }

            givenProbabilityProduct = givenProbabilityProduct * conditionalProbability;

            var distinctProbabilities = remainingPool.Distinct();
            return distinctProbabilities.Sum(x => Calculate(iteration - 1, new List<decimal>(remainingPool), x, givenProbabilityProduct));
        }
    }
}