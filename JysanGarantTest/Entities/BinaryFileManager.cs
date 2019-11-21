using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using JysanGarantTest.Abstraction;

namespace JysanGarantTest.Entities
{
   public  class BinaryFileManager : FileManager
    {
        BinaryFormatter formatter = new BinaryFormatter();
        public override void Write(string path, IEnumerable<Partner> partners)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, partners);
            }
        }

        public override IEnumerable<Partner>  Read(string path)
        {
            List<Partner> partners;
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                partners = (List<Partner>)formatter.Deserialize(fileStream);
            }
            return partners;
        }
    }
}
