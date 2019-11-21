using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JysanGarantTest.Abstraction
{
    public abstract class FileManager
    {
        public abstract void Write(string path, IEnumerable<Partner> partners);
        public abstract IEnumerable<Partner>  Read(string path);
    }
}
