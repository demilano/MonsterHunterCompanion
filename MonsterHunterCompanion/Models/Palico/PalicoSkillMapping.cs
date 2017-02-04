using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    public class PalicoSkillMapping
    {
        public int PalicoId { get; set; }

        public int PalicoSkillId { get; set; }

        [Key, Column(Order=0)]
        [ForeignKey("PalicoId")]
        public virtual Palico Palico { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("PalicoSkillId")]
        public virtual PalicoSkill PalicoSkill { get; set; }
    }
}