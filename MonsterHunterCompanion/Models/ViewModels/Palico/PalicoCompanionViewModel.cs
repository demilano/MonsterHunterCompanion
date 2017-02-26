using MonsterHunterCompanion.Models.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonsterHunterCompanion.Models.ViewModels.Palico
{
    public class PalicoCompanionViewModel
    {
        public PalicoCompanionViewModel()
        {
            SupportSkills = new SkillList();
            PassiveSkills = new SkillList();
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public int BiasId { get; set; }

        public List<SelectListItem> Biases { get; set; }

        public Dictionary<string, decimal> VillageProbabilities { get; set; }

        public SkillList SupportSkills { get; set; }

        public SkillList PassiveSkills { get; set; }
    }
}