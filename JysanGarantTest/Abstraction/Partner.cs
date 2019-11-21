using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JysanGarantTest.Abstraction
{
    [Serializable]
    public abstract class Partner
    {
        public int Id { get; set; }
        public string Iin { get; set; }
        public DateTime CreationDate { get; set; }  
    }
}
