using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}