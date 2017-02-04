using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    public class SkillPatternItem
    {
        [Key]
        public int SkillPatternItemId { get; set; }

        public int SkillPatternId { get; set; }

        public int SkillGroupId { get; set; }

        [ForeignKey("SkillPatternId")]
        public virtual SkillPattern SkillPattern { get; set; }

        [ForeignKey("SkillGroupId")]
        public virtual SkillGroup SkillGroup { get; set; }
    }
}