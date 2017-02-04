using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    /// <summary>
    ///  Can be one of: ....
    /// </summary>
    public class Bias
    {
        [Key]
        public int BiasId { get; set; }

        public string Name { get; set; }

        public int MaxSkillCost { get; set; }

        public virtual List<PalicoSkill> PalicoSkills { get; set; }

        public PalicoSkill PrimarySkill { get { return PalicoSkills.FirstOrDefault(x => x.SkillGroup.Group.Equals("P")); } }
    }
}