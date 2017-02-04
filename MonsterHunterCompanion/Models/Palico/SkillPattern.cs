using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    public class SkillPattern
    {
        [Key]
        public int SkillPatternId { get; set; }

        public virtual List<SkillPatternItem> SkillPatternList { get; set; }
    }
}