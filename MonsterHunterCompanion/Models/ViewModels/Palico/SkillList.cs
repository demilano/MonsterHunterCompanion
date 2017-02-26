using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonsterHunterCompanion.Models.ViewModels.Palico
{
    public class SkillList
    {
        public SkillList()
        {
            AvailableSkills = new List<SelectListItem>();
            SelectedSkills = new List<SelectListItem>();
        }

        public int SelectedSkillId { get; set; }

        public string SkillType { get; set; }

        public List<SelectListItem> AvailableSkills { get; set; }

        public List<SelectListItem> SelectedSkills { get; set; }

        public int CarouselIndex { get; set; }
    }
}