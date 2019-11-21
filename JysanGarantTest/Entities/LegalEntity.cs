using System;
using System.Collections;
using System.Collections.Generic;
using JysanGarantTest.Abstraction;

namespace JysanGarantTest.Entities
{
    [Serializable]
    public class LegalEntity : Partner
    {
        public string Name { get; set; }
        public List<Individual> ContactIndividuals { get; set; }
        public LegalEntity() => ContactIndividuals = new List<Individual>();

        public override string ToString()
        {
            return $"{Id};{Name};{Iin};{CreationDate.ToShortDateString()}";

        }


    }
}
