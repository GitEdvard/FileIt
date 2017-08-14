using System;
using System.Collections.Generic;
using System.Linq;
using FileIt.Interfaces;

namespace UnitTests.Utility
{
    class TestOsService: IOsService
    {
        public List<Tuple<string, string>> ChangedFiles { get; }

        public TestOsService()
        {
            ChangedFiles = new List<Tuple<string, string>>();
        }

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
            ChangedFiles.Add(new Tuple<string, string>(sourceFileName, destFileName));
        }
    }
}
