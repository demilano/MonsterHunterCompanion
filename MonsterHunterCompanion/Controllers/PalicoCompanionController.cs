using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.Controllers.Builders.Interfaces;
using MonsterHunterCompanion.Controllers.Builders;
using MonsterHunterCompanion.Models.ViewModels.Palico;
using MonsterHunterCompanion.PalicoProbabilityFinder;
using Newtonsoft.Json;

namespace MonsterHunterCompanion.Controllers
{
    public class PalicoCompanionController : Controller
    {
        private MonsterHunterCompanionDBContext _context;

        private readonly IPalicoCompanionViewModelBuilder _viewModelBuilder;

        public PalicoCompanionController()
        {
            _context = new MonsterHunterCompanionDBContext();
            _viewModelBuilder = new PalicoCompanionViewModelBuilder();
        }
        //
        // GET: /PalicoProbabilityFinder/

        public ActionResult Index()
        {
            var probabilityQueryHandler = new PalicoProbabilityQueryHandler();
            var bias = new Bias()
            {
                MaxSkillCost = 8,
                Name = "Assisting"
            };

          
            var skills = _context.PalicoSkills.Where(x => x.Name.Equals("Big Boomerang")).ToList();
          //  skills.Add(_context.PalicoSkills.Where(x => x.Name.Equals("Ultrasonic Horn")).FirstOrDefault());
           // skills.Add(_context.PalicoSkills.Where(x => x.Name.Equals("Explosive Roll")).FirstOrDefault());
          //  skills.Add(_context.PalicoSkills.Where(x => x.Name.Equals("Bounce Bombay")).FirstOrDefault());
            
           // var optionalSkills = _context.PalicoSkills.Where(x => x.Name.Equals("Parting Gift")).ToList();
         //   optionalSkills.Add(_context.PalicoSkills.Where(x => x.Name.Equals("Soothing Roll")).First());
             skills.Add(_context.PalicoSkills.Where(x => x.Name.Equals("Critical Up S")).FirstOrDefault());
             skills.Add(_context.PalicoSkills.Where(x => x.Name.Equals("Boomerang Pro")).FirstOrDefault());
             skills.Add(_context.PalicoSkills.Where(x => x.Name.Equals("Earplugs")).FirstOrDefault());
            skills.Add(_context.PalicoSkills.Where(x => x.Name.Equals("Piercing Boomerang")).FirstOrDefault());
           // skills.Add(_context.PalicoSkills.Where(x => x.Name.Equals("Pitfall Purr-ison")).FirstOrDefault());
            // For big boom, crit up s, boom pro, earplugs and piercing (for assist of fighting) probability is:
            // Bherna 0.0025, Kokoto 0.0198, Pokke 0.00061, Yukomo 0.00068
            /*var optionalSkills = _context.PalicoSkills.Where(x => x.Name.Equals("Parting Gift")).ToList();
             optionalSkills.Add(_context.PalicoSkills.Where(x => x.Name.Equals("Soothing Roll")).First());*/
            // After fix, next thing to try is 13 - 1 , and an optional skill. Should also be probabaility of 1
            // No because if there's only 1 optional skill, it's required. Must be a pool of 2+
            //actualTotalProb = 0.0007025833430249300724153543 optional
            /*var probability = probabilityQueryHandler.FindProbabilityForVillages(new PalicoProbabilityQuery()
            {
                Bias = bias,
                Skills = skills/*,
                OptionalSkills = optionalSkills
            });

            var totalProb = 1M;
            foreach(var thing in probability.Values)
            {
                totalProb = (totalProb * 1M - thing);
            }
            var actualTotalProb = 1M - totalProb;
   
            */
            return View(_viewModelBuilder.Build(_context));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PalicoCompanionViewModel model)
        {
            return View(_viewModelBuilder.Build(_context));
        }

        [HttpPost]
        public ActionResult CalculateProbabilities(PalicoCompanionViewModel model)
        {
            var probabilityQueryHandler = new PalicoProbabilityQueryHandler();
            var skillIds = model.SupportSkills.SelectedSkills.Select(x => Int32.Parse(x.Value)).ToList();
            skillIds.AddRange(model.PassiveSkills.SelectedSkills.Select(x => Int32.Parse(x.Value)));

            var query = new PalicoProbabilityQuery()
            {
                Bias = _context.Biases.First(x => x.BiasId == model.BiasId),
                Skills = _context.PalicoSkills.Where(x => skillIds.Contains(x.PalicoSkillId)).ToList(),
            };

            var probability = probabilityQueryHandler.FindProbabilityForVillages(query);

            return View("_villageProbabilities", probability);
        }

        [HttpPost]
        public ActionResult Populate(PalicoCompanionViewModel model)
        {
            return View("Index", model);
        }

        public bool AddSkill(int skillToAdd, PalicoCompanionViewModel model)
        {
            return false;
        }
    }
}