using BowCompanion.Controllers.Builders.Interfaces;
using BowCompanion.Models.BowCompanion;
using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.Models.DamageCalculator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BowCompanion.Controllers.Builders.Implementation
{
    public class BowCompanionViewModelBuilder : IBowCompanionViewModelBuilder
    {
        private MonsterHunterCompanionDBContext dbContext;

        public BowCompanionViewModelBuilder()
        {
            dbContext = new MonsterHunterCompanionDBContext();
        }
    
        public Models.BowCompanion.BowCompanionViewModel Build()
        {
            var bows = dbContext.Bows;

            var bow = bows.FirstOrDefault();

            var charge1 = bow.Charges.FirstOrDefault().ChargeLevel;

            var model = new BowCompanionViewModel()
            {
                Bows = bows.ToList(),
                Charges = dbContext.Charges
            };
            return model;
        }
    }
}