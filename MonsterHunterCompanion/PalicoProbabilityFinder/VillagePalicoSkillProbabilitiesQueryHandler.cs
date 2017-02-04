using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.PalicoProbabilityFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.PalicoProbabilityFinder
{
    public class VillagePalicoSkillProbabilitiesQueryHandler : IVillagePalicoSkillProbabilitiesQueryHandler
    {
        private readonly IVillageProbabilityDistributionQueryHandler _villageProbabilityDistributionQueryHandler;

        private readonly ITreeProbabilityCalculator _treeProbabilityCalculator;

        private static decimal PalicoPerVillage = 5; // Remove this later

        public VillagePalicoSkillProbabilitiesQueryHandler()
        {
            _villageProbabilityDistributionQueryHandler = new VillageProbabilityDistributionQueryHandler();
            _treeProbabilityCalculator = new TreeProbabilityCalculator();
        }

        public decimal GetProbability(VillagePalicoSkillProbabilitiesQuery query)
        {
            var villageProbabilities = _villageProbabilityDistributionQueryHandler.VillageProbabilitiesByName(query.VillageName);
            var skillTypes = query.Skills.Where(x => x.SkillGroup.Cost > 0).Select(x => x.SkillTypeId).Distinct();

            var totalProbability = query.InitialProbability > 0 ? query.InitialProbability : 1M;
            IEnumerable<VillageProbability> villageSkillProbabilitiesForGroup;
            List<decimal> initialPool;
            int groupCount;
            var villageSkillProbability = 0M;
            IEnumerable<string> groupsToCheck;
            IEnumerable<PalicoSkill> skillsForType;
            var skillProbabilityForType = 1M;
            var skillProbabilityForGroup = 0M;

            foreach(var skillTypeId in skillTypes)
            {
                skillsForType = query.Skills.Where(x => x.SkillGroup.Cost > 0).Where(x => x.SkillTypeId == skillTypeId);
                groupsToCheck = skillsForType.Select(y => y.SkillGroup.Group).Distinct();
                skillProbabilityForType = 1M;

                foreach (var group in groupsToCheck)
                {
                    villageSkillProbabilitiesForGroup = villageProbabilities.Where(x => x.PalicoSkill.SkillGroup.Group.Equals(group) && x.PalicoSkill.SkillTypeId == skillTypeId);//supportSkills.Any(y => y.PalicoSkillId == x.PalicoSkill.PalicoSkillId) 
                    skillProbabilityForGroup = 0;

                    foreach (var pattern in query.SkillPatterns)
                    {
                        // i.e, number of times the desired skill group appears. If 0, prob for that pattern is 0
                        // for 1, the probability is the village probability
                        // for over 1, we need to use conditional probability
                        groupCount = pattern.SkillPatternList.Count(y => y.SkillGroup.Group.Equals(group)); // Depth of tree

                        initialPool = villageSkillProbabilitiesForGroup.Select(x => x.Probability).ToList(); // This is all of the village probabilities by group, which should initially sum to 1 (100%)
                        villageSkillProbability = 0M;

                        foreach (var skillByGroup in skillsForType.Where(x => x.SkillGroup.Group.Equals(group)))
                        {
                            villageSkillProbability = villageSkillProbabilitiesForGroup.FirstOrDefault(x => x.PalicoSkill.PalicoSkillId == skillByGroup.PalicoSkillId).Probability;
                            initialPool.Remove(villageSkillProbability);
                            initialPool.Add(-villageSkillProbability);
                        }

                        // We need to identify one of the pool as ours, so we will make it negative
                        // This first one should be a sum
                        var distinctProbabilities = initialPool.Distinct();
                        var patternSkillProbability = distinctProbabilities.Sum(x => _treeProbabilityCalculator.Calculate(groupCount, new List<decimal>(initialPool), x, 1)); // Probability of this skill in this pattern

                        skillProbabilityForGroup += patternSkillProbability * 1 / query.SkillPatterns.Count();
                    };

                    // Since groups are independent given patterns, we can just multiple for total Probability
                    skillProbabilityForType = skillProbabilityForType * skillProbabilityForGroup;
                }

                totalProbability = totalProbability * skillProbabilityForType; // And again, independent so can multiply
            }

            // TotalProability here is for a single Palico to have all these skills. 
            // Since there are 5 cats in the village, we find the total probability (perhaps return them separately?)
            return 1M - Power(1M - totalProbability, PalicoPerVillage);
        }

        private decimal Power(decimal totalProbability, decimal exponent)
        {
            if(exponent == 0)
            {
                return 1;
            }

            return totalProbability * Power(totalProbability, exponent - 1);
        }
    }
}