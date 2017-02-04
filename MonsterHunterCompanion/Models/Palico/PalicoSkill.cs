using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    public class PalicoSkill
    {
        [Key]
        public int PalicoSkillId { get; set; }

        public string Name { get; set; }

        public int SkillTypeId { get; set; }

        public int SkillGroupId { get; set; }

        // Add in Bias later, for Primary Skills
        public int? BiasId { get; set; }

        [ForeignKey("BiasId")]
        public virtual Bias Bias { get; set; }

        [ForeignKey("SkillTypeId")]
        public virtual SkillType SkillType { get; set; }

        [ForeignKey("SkillGroupId")]
        public virtual SkillGroup SkillGroup { get; set; }
    }
}