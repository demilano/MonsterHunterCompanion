using MonsterHunterCompanion.Controllers.Builders.Interfaces;
using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.Models.ViewModels.Palico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonsterHunterCompanion.Controllers.Builders
{
    public class PalicoCompanionViewModelBuilder : IPalicoCompanionViewModelBuilder
    {
        // Can pass through existing Palico
        public PalicoCompanionViewModel Build(MonsterHunterCompanionDBContext context)
        {
            var viewModel = new PalicoCompanionViewModel();
            var biases = context.Biases.ToList();
            viewModel.Biases = new List<SelectListItem>();
            foreach(var bias in biases)
            {
                viewModel.Biases.Add(new SelectListItem()
                    {
                        Text = bias.Name,
                        Value = bias.BiasId.ToString()
                    });
            }
            viewModel.VillageProbabilities = new Dictionary<string, decimal>();
            context.Villages.ToList().ForEach(x => viewModel.VillageProbabilities.Add(x.Name, 0M));
            
            viewModel.SupportSkills = new SkillList()
            {
                SkillType = "Support",
                CarouselIndex = 0
            };
            viewModel.PassiveSkills = new SkillList()
            {
                SkillType = "Passive",
                CarouselIndex = 1
            };

            context.PalicoSkills.Where(x => x.SkillType.Name.Equals(viewModel.SupportSkills.SkillType, StringComparison.InvariantCultureIgnoreCase)).ToList().ForEach(x => viewModel.SupportSkills.AvailableSkills.Add(new SelectListItem()
            {
                Text = x.Name,
                Value = x.PalicoSkillId.ToString()
            }));
            context.PalicoSkills.Where(x => x.SkillType.Name.Equals(viewModel.PassiveSkills.SkillType, StringComparison.InvariantCultureIgnoreCase)).ToList().ForEach(x => viewModel.PassiveSkills.AvailableSkills.Add(new SelectListItem()
            {
                Text = x.Name,
                Value = x.PalicoSkillId.ToString()
            }));


            return viewModel;
        }
    }
}