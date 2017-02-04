using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    public class VillageProbability
    {
        [Key]
        public int VillageProbabilityId { get; set; }

        public decimal Probability { get; set; }

        public int VillageId { get; set; }

        public int PalicoSkillId { get; set; }

        [ForeignKey("VillageId")]
        public virtual Village Village { get; set; }

        [ForeignKey("PalicoSkillId")]
        public virtual PalicoSkill PalicoSkill { get; set; } 
    }
}