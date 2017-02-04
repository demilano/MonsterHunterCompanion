using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.PalicoProbabilityFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.PalicoProbabilityFinder
{
    public class VillageQueryHandler : IVillageQueryHandler
    {
        private MonsterHunterCompanionDBContext _context;

        public VillageQueryHandler()
        {
            _context = new MonsterHunterCompanionDBContext();
        }
        public List<Village> GetVillages()
        {
            return _context.Villages.ToList();
        }
    }
}