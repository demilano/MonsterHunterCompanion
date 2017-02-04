using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonsterHunterCompanion.Models.DamageCalculator;
using BowCompanion.Controllers.Builders.Implementation;
using BowCompanion.Controllers.Builders;
using BowCompanion.BowDamageCalculator.Prepopulators;
using MonsterHunterCompanion.Models.DamageCalculator.Weapons.Bow;
using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.PalicoProbabilityFinder;
using BowCompanion.Controllers.Builders.Interfaces;

namespace BowCompanion.Controllers
{
    public class BowCompanionController : Controller
    {
        private MonsterHunterCompanionDBContext db = new MonsterHunterCompanionDBContext();

        private IBowCompanionViewModelBuilder builder;

        public BowCompanionController()
        {
            builder = new BowCompanionViewModelBuilder();
        }

        //
        // GET: /BowCompanion/

        public ActionResult Index()
        {
      //      var bow = WeaponPrepopulator.GetUkanlosSkyFlier();
         //   db.Bows.Add(bow);
        ///    db.SaveChanges();
        ///    

            TestMethod();

            var model = builder.Build();

            return View(model);
        }

        public void TestMethod()
        {
            var probabilityQueryHandler = new PalicoProbabilityQueryHandler();
            var bias = new Bias()
            {
                MaxSkillCost = 8,
                Name = "Fighting"
            };

            var skills = db.PalicoSkills.Where(x => x.Name.Equals("Big Boomerang")).ToList();
            skills.Add(db.PalicoSkills.Where(x => x.Name.Equals("Critical Up S")).FirstOrDefault());
            skills.Add(db.PalicoSkills.Where(x => x.Name.Equals("Boomerang Pro")).FirstOrDefault());
            skills.Add(db.PalicoSkills.Where(x => x.Name.Equals("Earplugs")).FirstOrDefault());
         //   skills.Add(db.PalicoSkills.Where(x => x.Name.Equals("Dung Bombay")).FirstOrDefault());


            var probability = probabilityQueryHandler.FindProbabilityForVillages(new PalicoProbabilityQuery()
            {
                Bias = bias,
                Skills = skills
            });
        }

        //
        // GET: /BowCompanion/Details/5

        public ActionResult Details(int id = 0)
        {
            Weapon weapon = db.Weapons.Find(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        //
        // GET: /BowCompanion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BowCompanion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bow bow)
        {
            if (ModelState.IsValid)
            {
                //db.Weapons.Add(bow);
                db.Bows.Add(bow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bow);
        }

        //
        // GET: /BowCompanion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Weapon weapon = db.Weapons.Find(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        //
        // POST: /BowCompanion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weapon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weapon);
        }

        //
        // GET: /BowCompanion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Weapon weapon = db.Weapons.Find(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        //
        // POST: /BowCompanion/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weapon weapon = db.Weapons.Find(id);
            db.Weapons.Remove(weapon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}