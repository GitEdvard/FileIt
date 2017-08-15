using System;
using System.IO;
using FileIt.Interfaces;

namespace FileIt.Common
{
    class ProductionOsService: IOsService
    {
        public string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        public void WriteLineToConsole(string str)
        {
            Console.WriteLine(str);
        }

        public void MoveFile(string sourceFileName, string destFileName)
        {
            File.Move(sourceFileName, destFileName);
        }
    }
}
