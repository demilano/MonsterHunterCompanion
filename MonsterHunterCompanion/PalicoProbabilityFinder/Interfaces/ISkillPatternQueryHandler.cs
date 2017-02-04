using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.PalicoProbabilityFinder.Interfaces
{
    public interface ISkillPatternQueryHandler
    {
        List<SkillPattern> GetSkillPatterns(Bias bias);
    }
}