using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    public class Palico
    {
        [Key]
        public int PalicoId { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }
        // A bit annoying that I need to specify the column names for foreign keys 
        // If I don't want to use the default table_key
        public int BiasId { get; set; }

        // Get primary skill

        // Get secondary skill

        [ForeignKey("BiasId")]
        public virtual Bias Bias { get; set; }

        public virtual IEnumerable<PalicoSkill> Skills { get; set; }

        [NotMapped]
        public IEnumerable<PalicoSkill> PassiveSkills {
            get
            {
                return Skills.Where(x => x.Name.Equals("Passive"));
            }
        }

        [NotMapped]
        public IEnumerable<PalicoSkill> SupportSkills {
            get
            {
                return Skills.Where(x => x.Name.Equals("Support"));
            }
        }
    }
}