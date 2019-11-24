using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JysanGarantTest.Abstraction;
using JysanGarantTest.Entities;


namespace JysanGarantTest
{
    class Program
    {
        private const string _path = @"c:\temp\partners.txt";
        static void Main(string[] args)
        {
            try
            {
                var fileExecutor = new FileManagerExecutor(new SimpleFileManager());

                var partners = Initial();
                fileExecutor.Write(_path, partners);

                var contragents = fileExecutor.Read(_path);
                var individuals = contragents.Where(x => x is Individual).OrderBy(x => ((Individual)x).LastName)
                                                                          .ThenBy(x => ((Individual)x).FirstName);
                Console.WriteLine("Физ.лица:");
                foreach (var individual in individuals)
                {
                    Console.WriteLine(individual);
                }


                Console.WriteLine("____________________________________________________________________");

                var legals = contragents.Where(x => x is LegalEntity).Take(5).ToList()
                                        .OrderByDescending(x => ((LegalEntity)x).ContactIndividuals.Count);

                foreach (var legalEntity in legals)
                {
                    Console.WriteLine($"ЮР лицо:\n{legalEntity}");
                    Console.WriteLine("Список контактных лиц:");

                    foreach (var l in (legalEntity as LegalEntity)?.ContactIndividuals)
                    {

                        Console.WriteLine(l);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadKey();
        }

        //-----------------------------------------------------
        private static IEnumerable<Partner> Initial()
        {
            List<Partner> partners = new List<Partner>();
            List<Individual> individuals = new List<Individual>();
            for (int i = 1; i <= 15; i++)
            {
                var individual = new Individual
                {
                    Id = i,
                    Iin = $"44445555666{i}",
                    FirstName = $"FName_{i}",
                    LastName = $"LName_{i}",
                    Patronymic = $"PName_{i}",
                    CreationDate = DateTime.Now,
                    LegalEntityId = i
                };
                individuals.Add(individual);
            }
            for (int i = 0; i <= 8; i++)
            {
                var legalEntity = new LegalEntity
                {
                    Id = (i + 1),
                    CreationDate = DateTime.Now.AddDays(-(i + 1)),
                    Iin = $"11112222333{i}",
                    Name = $"Name_{i + 1}"
                };
                partners.Add(legalEntity);
            }

            individuals[5].LegalEntityId = 3;
            individuals[6].LegalEntityId = 3;
            individuals[2].LegalEntityId = 3;
            individuals[7].LegalEntityId = 4;
            individuals[8].LegalEntityId = 4;
            individuals[11].LegalEntityId = 4;
            individuals[13].LegalEntityId = 4;
            partners.AddRange(individuals);
            return partners;
        }
    }
}
