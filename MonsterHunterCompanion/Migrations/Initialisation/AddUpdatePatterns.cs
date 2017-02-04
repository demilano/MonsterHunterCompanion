using MonsterHunterCompanion.Models.DamageCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using MonsterHunterCompanion.Models.Palico;
using MonsterHunterCompanion.Models;

namespace MonsterHunterCompanion.Migrations.Initialisation
{
    public class AddUpdatePatterns
    {
        public static void AddOrUpdate(MonsterHunterCompanionDBContext context)
        {
            var skillGroupA = context.PalicoSkillGroups.FirstOrDefault(x => x.Group.Equals("A"));
            var skillGroupB = context.PalicoSkillGroups.FirstOrDefault(x => x.Group.Equals("B"));
            var skillGroupC = context.PalicoSkillGroups.FirstOrDefault(x => x.Group.Equals("C"));

            var patterns = new List<List<SkillGroup>>();
            patterns.Add(new List<SkillGroup>() { GetCopy(skillGroupA), GetCopy(skillGroupB), GetCopy(skillGroupB), GetCopy(skillGroupC) });
            patterns.Add(new List<SkillGroup>() { GetCopy(skillGroupA), GetCopy(skillGroupB), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC) });
            patterns.Add(new List<SkillGroup>() { GetCopy(skillGroupA), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC) });
            patterns.Add(new List<SkillGroup>() { GetCopy(skillGroupB), GetCopy(skillGroupB), GetCopy(skillGroupB), GetCopy(skillGroupB) });
            patterns.Add(new List<SkillGroup>() { GetCopy(skillGroupB), GetCopy(skillGroupB), GetCopy(skillGroupB), GetCopy(skillGroupC), GetCopy(skillGroupC) });
            patterns.Add(new List<SkillGroup>() { GetCopy(skillGroupB), GetCopy(skillGroupB), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC) });
            patterns.Add(new List<SkillGroup>() { GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC), GetCopy(skillGroupC) });

            Dictionary<string, int> groupCount;
            var patternExists = false;
            var existingPatternQuery = from p in context.SkillPatterns
                                   select p.SkillPatternList;

            var existingPatterns = existingPatternQuery.ToList();

            var patternString = String.Empty;

           foreach(var pattern in patterns) // List of skill groups
           {
               // now we have a count of those, we check existing patterns
               patternString = pattern.OrderBy(x => x.Group).Select(y => y.Group).Aggregate((a, b) => a + b);
               patternExists = PatternExists(patternString, existingPatterns);
               if(!patternExists)
               {
                   var skillPattern = new SkillPattern();
                   skillPattern.SkillPatternList = (from g in pattern
                                                    select new SkillPatternItem() { SkillGroupId = g.SkillGroupId }).ToList();


                   context.SkillPatterns.AddOrUpdate(x => x.SkillPatternId, skillPattern);
               }
           }
        }

        private static bool PatternExists(string patternString, List<List<SkillPatternItem>> existingPatterns)
        {
            var existingPatternString = String.Empty;

            foreach (var existingPattern in existingPatterns)
            {
                existingPatternString = existingPattern.OrderBy(x => x.SkillGroup.Group).Select(y => y.SkillGroup.Group).Aggregate((a, b) => a + b);
                if(existingPatternString.Equals(patternString))
                {
                    return true;
                }
            }

            return false;
        }

        private static Dictionary<string, int> InitialiseGroupCount()
        {
            var groupCount = new Dictionary<string, int>();
            groupCount.Add("A", 0);
            groupCount.Add("B", 0);
            groupCount.Add("C", 0);
            return groupCount;

        }

        private static SkillGroup GetCopy(SkillGroup skillToCopy)
        {
            return new SkillGroup()
            {
                Cost = skillToCopy.Cost,
                Group = skillToCopy.Group,
                SkillGroupId = skillToCopy.SkillGroupId
            };
        }
    }
}