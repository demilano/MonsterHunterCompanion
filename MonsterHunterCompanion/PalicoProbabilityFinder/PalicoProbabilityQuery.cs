using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.PalicoProbabilityFinder
{
    public class PalicoProbabilityQuery
    {
        public PalicoProbabilityQuery()
        {
            Skills = new List<PalicoSkill>();
            OptionalSkills = new List<PalicoSkill>();
        }

        public List<PalicoSkill> Skills { get; set; }

        public Bias Bias { get; set; }

        public List<PalicoSkill> OptionalSkills { get; set; }
    }
}