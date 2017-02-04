using MonsterHunterCompanion.Models.DamageCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using MonsterHunterCompanion.Models;
using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.Migrations.Initialisation.VillageProbabilities;

namespace MonsterHunterCompanion.Migrations.Initialisation
{
    public class AddUpdateVillageProbabilities
    {
        public static void AddUpdate(MonsterHunterCompanionDBContext context)
        {
            var allPalicoSkills = context.PalicoSkills.ToList();

            // First get Bherna
            var villageId = context.Villages.FirstOrDefault(x => x.Name.Equals("Bherna")).VillageId;
            var probabilityDictionary = GetBhernaVillageProbabilities.Get();
            var probabilities = probabilityDictionary.Keys.Select(x => new VillageProbability()
            {
                PalicoSkillId = allPalicoSkills.FirstOrDefault(y => y.Name.Equals(x)).PalicoSkillId,
                Probability = probabilityDictionary[x],
                VillageId = villageId
            }).ToArray();
            context.VillageProbabilities.AddOrUpdate(x => new { x.PalicoSkillId, x.VillageId }, probabilities);

            // Then Kokoto
            villageId = context.Villages.FirstOrDefault(x => x.Name.Equals("Kokoto")).VillageId;
            probabilityDictionary = GetKotokoVillageProbabilities.Get();
            probabilities = probabilityDictionary.Keys.Select(x => new VillageProbability()
            {
                PalicoSkillId = allPalicoSkills.FirstOrDefault(y => y.Name.Equals(x)).PalicoSkillId,
                Probability = probabilityDictionary[x],
                VillageId = villageId
            }).ToArray();
            context.VillageProbabilities.AddOrUpdate(x => new { x.PalicoSkillId, x.VillageId }, probabilities);

            // Then Pokke
            villageId = context.Villages.FirstOrDefault(x => x.Name.Equals("Pokke")).VillageId;
            probabilityDictionary = GetPokkeVillageProbabilities.Get();
            probabilities = probabilityDictionary.Keys.Select(x => new VillageProbability()
            {
                PalicoSkillId = allPalicoSkills.FirstOrDefault(y => y.Name.Equals(x)).PalicoSkillId,
                Probability = probabilityDictionary[x],
                VillageId = villageId
            }).ToArray();
            context.VillageProbabilities.AddOrUpdate(x => new { x.PalicoSkillId, x.VillageId }, probabilities);

            // Then Yukumo
            villageId = context.Villages.FirstOrDefault(x => x.Name.Equals("Yukumo")).VillageId;
            probabilityDictionary = GetYukomoVillageProbabilities.Get();
            probabilities = probabilityDictionary.Keys.Select(x => new VillageProbability()
            {
                PalicoSkillId = allPalicoSkills.FirstOrDefault(y => y.Name.Equals(x)).PalicoSkillId,
                Probability = probabilityDictionary[x],
                VillageId = villageId
            }).ToArray();
            context.VillageProbabilities.AddOrUpdate(x => new { x.PalicoSkillId, x.VillageId }, probabilities);
        }
    }
}