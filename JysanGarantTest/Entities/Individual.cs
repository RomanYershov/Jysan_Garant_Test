using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JysanGarantTest.Abstraction;

namespace JysanGarantTest.Entities
{
    [Serializable]
    public class Individual : Partner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Patronymic { get; set; }
        public int LegalEntityId { get; set; }  

        public override string ToString()
        {
            return
                $"{Id};{LastName};{FirstName};{Patronymic};{Iin};{CreationDate.ToShortDateString()};{LegalEntityId}"; 
        }
    }
}
