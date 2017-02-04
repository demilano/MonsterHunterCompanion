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
            viewModel.Skills = new List<SelectListItem>();
            viewModel.SelectedSkills = new List<PalicoSkill>();
            viewModel.SelectedSkills.Add(new PalicoSkill()
                {
                    Name = "poodle"
                });
            context.PalicoSkills.ToList().ForEach(x => viewModel.Skills.Add(new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.PalicoSkillId.ToString()
                }));

            viewModel.Things = new List<string>();
            viewModel.Things.Add("Pooo");

            return viewModel;
        }
    }
}