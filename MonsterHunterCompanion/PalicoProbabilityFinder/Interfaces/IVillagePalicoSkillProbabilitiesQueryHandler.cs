using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.PalicoProbabilityFinder.Interfaces
{
    public interface IVillagePalicoSkillProbabilitiesQueryHandler
    {
        decimal GetProbability(VillagePalicoSkillProbabilitiesQuery query);
    }
}