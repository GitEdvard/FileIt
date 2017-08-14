using System;
using System.Linq;
using FileIt.Interfaces;

namespace UnitTests.Utility
{
    class TestOsService: IOsService
    {
        public string GetFileName(string path)
        {
            string[] sep = {@"/", @"\"};
            var split = path.Split(sep, StringSplitOptions.None);
            return split.ToList().LastOrDefault(x => true);
        }

        public void WriteLineToConsole(string str)
        {
        }

        public void MoveFile(string sourceFileName, string destFileName)
        {
        }
    }
}
