using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.Models.DamageCalculator;
using MonsterHunterCompanion.PalicoProbabilityFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonsterHunterCompanion.Models;

namespace MonsterHunterCompanion.PalicoProbabilityFinder
{
    /// <summary>
    /// The patterns:
    /// A, B, B, B *
    /// A, B, B, C
    /// A, B, C, C, C
    /// A, C, C, C, C, C
    /// B, B, B, B
    /// B, B, B, C, C
    /// B, B, C, C, C, C
    /// C, C, C, C, C, C, C, C **
    /// * This totals 9 points and is possible only for Charisma cats. In addition, add one C skill to the end of every other setup for Charisma cats
    /// ** B, C, C, C, C, C, C is not a valid combination even though it conforms to the rules. Why? Who knows.
    /// </summary>
    public class SkillPatternQueryHandler : ISkillPatternQueryHandler
    {
        private MonsterHunterCompanionDBContext _dbContext;
        
        public SkillPatternQueryHandler()
        {
            _dbContext = new MonsterHunterCompanionDBContext();
        }

        public List<SkillPattern> GetSkillPatterns(Bias bias)
        {
            var patternQuery = from p in _dbContext.SkillPatterns
                                select p;

            var patterns = patternQuery.ToList() ;

            var costOneGroup = (from g in _dbContext.PalicoSkillGroups
                                    select g).Where(x => x.Cost == 1).FirstOrDefault();

            // For charisma, their max cost is 9 because they lack a unique secondary
            // We could be even more clever and base it on that fact, but we shall not (it would be globa maxskillcost - non-primary skills
            // Keep adding 1 cost until it reaches max skill cost for the bias. Again, we shouldn't need to store patterns
            // Since we can calculate them, but it's easier this way.
            foreach(var pattern in patterns)
            {
                while(pattern.SkillPatternList.Sum(y => y.SkillGroup.Cost) < bias.MaxSkillCost)
                {
                    pattern.SkillPatternList.Add(new SkillPatternItem()
                    {
                        SkillGroup = costOneGroup
                    });
                }
            }

            return patterns.ToList();
        }
    }
}