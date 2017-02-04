using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.Models.ViewModels.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterHunterCompanion.Controllers.Builders.Interfaces
{
    public interface IPalicoCompanionViewModelBuilder
    {
        PalicoCompanionViewModel Build(MonsterHunterCompanionDBContext context);
    }
}