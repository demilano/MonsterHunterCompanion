using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.PalicoProbabilityFinder
{
    public class VillagePalicoSkillProbabilitiesQuery
    {
        public string VillageName { get; set; }

        public List<PalicoSkill> Skills { get; set; }

        public List<PalicoSkill> OptionalSkills { get; set; }

        public List<SkillPattern> SkillPatterns { get; set; }

        public decimal InitialProbability { get; set; }
    }
}