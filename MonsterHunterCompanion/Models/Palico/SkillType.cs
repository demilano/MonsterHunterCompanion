using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    public class SkillType
    {
        [Key]
        public int SkillTypeId { get; set; }

        public string Name { get; set; }
    }
}