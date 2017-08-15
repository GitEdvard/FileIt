using System;
using System.IO;
using FileIt.Interaces;

namespace FileIt.UserOptions.FindReplace
{
    public class FindReplaceInFileName: ISingleFileProcessor
    {
        public void Dispose()
        {
        }

        public void Process(string file, string[] args)
        {
            var argProvider = new ArgumentProvider(args);
            var fileName = Path.GetFileName(file);
            var newFileName = fileName.Replace(argProvider.FindWhat, argProvider.ReplaceWith);
            Console.WriteLine($"{fileName} --> {newFileName}");
            var newFilePath = file.Replace(fileName, newFileName);
            File.Move(file, newFilePath);
        }

        public void Init(string path)
        {
        }
    }
}
