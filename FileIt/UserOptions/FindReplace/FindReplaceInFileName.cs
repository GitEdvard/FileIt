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
            var findStr = args[3];
            var replaceStr = "";
            if (args.Length > 4)
            {
                replaceStr = args[4];
            }
            var fileName = Path.GetFileName(file);
            var newFileName = fileName.Replace(findStr, replaceStr);
            Console.WriteLine($"{fileName} --> {newFileName}");
            var newFilePath = file.Replace(fileName, newFileName);
            File.Move(file, newFilePath);
        }

        public void Init(string path)
        {
        }
    }
}
