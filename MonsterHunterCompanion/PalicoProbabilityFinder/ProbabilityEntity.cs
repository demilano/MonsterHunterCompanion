﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.PalicoProbabilityFinder
{
    public class ProbabilityEntity
    {
        public decimal Probability { get; set; }

        // If there's only one optional skill, it's required
        // If there are multiple, only 1 of them is required
        public bool IsAnOptionalRequirement { get; set; }

        // Different from IsOptionalRequirement since the probabilities aren't
        // looking at are IsOptionalRequirement = false, so need to distinguish between
        // those and the required probabilities
        public bool IsRequired { get; set; }
    }
}