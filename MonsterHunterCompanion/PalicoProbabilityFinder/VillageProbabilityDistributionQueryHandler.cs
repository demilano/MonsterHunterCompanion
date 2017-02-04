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
    public class VillageProbabilityDistributionQueryHandler : IVillageProbabilityDistributionQueryHandler
    {
        private MonsterHunterCompanionDBContext _dbContext; 

        public VillageProbabilityDistributionQueryHandler()
        {
            _dbContext = new MonsterHunterCompanionDBContext();
        }

        public List<VillageProbability> VillageProbabilitiesByName(string villageName)
        {
            return (from p in _dbContext.VillageProbabilities
                    select p).Where(x => x.Village.Name.Equals(villageName)).ToList();
        }
    }
}