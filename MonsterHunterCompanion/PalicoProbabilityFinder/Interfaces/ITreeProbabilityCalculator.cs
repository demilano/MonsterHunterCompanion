using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.PalicoProbabilityFinder.Interfaces
{
    public interface ITreeProbabilityCalculator
    {
        decimal Calculate(int iteration, List<TreeProbabilityEntity> remainingPool, TreeProbabilityEntity givenValue, decimal givenProbabilityProduct);
    }
}