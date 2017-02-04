using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.PalicoProbabilityFinder.Interfaces;
using MonsterHunterCompanion.PalicoProbabilityFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonsterHunterCompanion.Models;

namespace MonsterHunterCompanion.PalicoProbabilityFinder
{
    public class PalicoProbabilityQueryHandler : IPalicoProbabilityQueryHandler
    {
        private readonly ISkillPatternQueryHandler _skillPatternQueryHandler;

        private readonly IVillageProbabilityDistributionQueryHandler _villageProbabilityDistributionQueryHandler;

        private readonly IVillagePalicoSkillProbabilitiesQueryHandler _villagePalicoSkillProbabilitiesQueryHandler;

        private readonly IVillageQueryHandler _villageQueryHandler;

        public PalicoProbabilityQueryHandler()
        {
            _skillPatternQueryHandler = new SkillPatternQueryHandler();
            _villageProbabilityDistributionQueryHandler = new VillageProbabilityDistributionQueryHandler();
            _villageQueryHandler = new VillageQueryHandler();
            _villagePalicoSkillProbabilitiesQueryHandler = new VillagePalicoSkillProbabilitiesQueryHandler();
        }

        // To test, have a pattern of 13 of one group. It should equal one
        // To test multiple skills, I think I can just multiple them? 
        public Dictionary<string, decimal> FindProbabilityForVillages(PalicoProbabilityQuery query)
        {
            ValidateQuery(query); // Query containing a list of skills.

            decimal totalProbabilitySoFar = 1;

            if(query.Skills.Any(x => x.SkillGroup.Group.Equals("S")))
            {
                // Have already validated that there is maximum one secondary, and that it belongs to that palico
                totalProbabilitySoFar *= 0.5M; // If I wanted to be super, I'd do it as count / max secondaries for that bias
            }

            // The query won't specify village, we will jsut check them all and return a dictionary of village + probability
            var villageProbabilityDictionary = new Dictionary<string, decimal>();

            var skillPatterns = _skillPatternQueryHandler.GetSkillPatterns(query.Bias);
            // We can loop on biases too later if need be
            foreach(var village in _villageQueryHandler.GetVillages())
            {
                // support skill
                villageProbabilityDictionary.Add(village.Name, 
                    _villagePalicoSkillProbabilitiesQueryHandler.GetProbability(new VillagePalicoSkillProbabilitiesQuery()
                    {
                        VillageName = village.Name,
                        Skills = query.Skills,
                        SkillPatterns = skillPatterns,
                        InitialProbability = totalProbabilitySoFar
                    }));     
            }

            return villageProbabilityDictionary;
        }

        private void ValidateQuery(PalicoProbabilityQuery query)
        {
            // If Score > maxScoreForBias, return false
            // If contains more than one A, return false
            // Skills are unique (I think that will be constrained on page anyway)
            // Other than that, it's fine
        }
    }
}