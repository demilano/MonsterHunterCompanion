using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.PalicoProbabilityFinder
{
    public class PalicoProbabilityQuery
    {
        public List<PalicoSkill> Skills { get; set; }

        public Bias Bias { get; set; }
    }
}