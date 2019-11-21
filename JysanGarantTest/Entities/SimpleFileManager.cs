using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JysanGarantTest.Abstraction;

namespace JysanGarantTest.Entities
{
    public class SimpleFileManager : FileManager
    {
        public override void Write(string path, IEnumerable<Partner> partners)
        {
            List<string> list = new List<string>();
            foreach (var partner in partners)
            {
                if (partner is LegalEntity legal)
                {
                    list.Add(legal.ToString());
                }
                else if (partner is Individual individual)
                {
                    list.Add(individual.ToString());
                }
            }
            File.WriteAllText(path, string.Empty);
            File.AppendAllLines(path, list);
        }

        public override IEnumerable<Partner> Read(string path)
        {
            string[] resStringArr = default(string[]);
            try
            {
                resStringArr = File.ReadAllLines(path); //todo
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var partners = GetEntityByString(resStringArr);
            return partners;
        }

        private IEnumerable<Partner> GetEntityByString(string[] str)
        {
            List<Partner> partners = new List<Partner>();
            List<Individual> individuals = new List<Individual>();
            List<LegalEntity> legalEntities = new List<LegalEntity>();
            foreach (var s in str)
            {
                var resArr = s.Split(';');
                if (resArr.Length == 4)
                {
                    var legal = new LegalEntity
                    {
                        Id = int.Parse(resArr[0]),
                        Name = resArr[1],
                        Iin = resArr[2],
                        CreationDate = DateTime.Parse(resArr[3])
                    };
                    legalEntities.Add(legal);
                   
                }
                else
                {
                    var individual = new Individual
                    {
                        Id = int.Parse(resArr[0]),
                        FirstName = resArr[1],
                        LastName = resArr[2],
                        Patronymic = resArr[3],
                        Iin = resArr[4],
                        CreationDate = DateTime.Parse(resArr[5]),
                        LegalEntityId = int.Parse(resArr[6])
                    };
                    individuals.Add(individual);
                }   
            }

            foreach (var individual in individuals)
            {
                    legalEntities.FirstOrDefault(x => x.Id == individual.LegalEntityId)?.ContactIndividuals.Add(individual);
            }
            partners.AddRange(individuals);
            partners.AddRange(legalEntities);
            return partners;
        }
    }
}
