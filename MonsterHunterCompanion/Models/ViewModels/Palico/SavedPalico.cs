using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.ViewModels.Palico
{
    public class SavedPalico
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int BiasId { get; set; }

        public FurColours FurColours { get; set; }

        public SkillList SupportSkills { get; set; }

        public SkillList PassiveSkills { get; set; }
    }
}