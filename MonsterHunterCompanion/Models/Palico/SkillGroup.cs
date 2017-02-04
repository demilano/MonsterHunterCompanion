using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    public class SkillGroup
    {
        [Key]
        public int SkillGroupId { get; set; }

        [StringLength(1), Column(TypeName = "char")]
        public string Group { get; set; }

        public string GroupDescription { get; set; }

        public int Cost { get; set; }
    }
}