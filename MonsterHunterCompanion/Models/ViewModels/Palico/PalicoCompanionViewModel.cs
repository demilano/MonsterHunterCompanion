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
        public string Name { get; set; }

        public int Level { get; set; }

        public int BiasId { get; set; }

        public List<SelectListItem> Biases { get; set; }

        public Dictionary<string, decimal> VillageProbabilities { get; set; }

        public int SkillId { get; set; }

        public List<SelectListItem> Skills { get; set; }

        public List<PalicoSkill> SelectedSkills { get; set; }

        public List<string> Things { get; set; }
    }
}