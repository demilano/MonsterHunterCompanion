using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Models.Palico
{
    public class Village
    {
        [Key]
        public int VillageId { get; set; }

        public string Name { get; set; }
    }
}