using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JysanGarantTest.Abstraction;

namespace JysanGarantTest.Entities
{
    public class FileManagerExecutor
    {
        private FileManager _file;
        public FileManagerExecutor(FileManager fileManager) => _file = fileManager;

        public void Write(string path, IEnumerable<Partner> partners)
        {
            _file.Write(path,partners);
        }

        public IEnumerable<Partner> Read(string path)
        {
            return _file.Read(path);
        }
    }
}
