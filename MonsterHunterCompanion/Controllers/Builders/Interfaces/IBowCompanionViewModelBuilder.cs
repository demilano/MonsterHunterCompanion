using BowCompanion.Models.BowCompanion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowCompanion.Controllers.Builders.Interfaces
{
    public interface IBowCompanionViewModelBuilder
    {
        BowCompanionViewModel Build();
    }
}