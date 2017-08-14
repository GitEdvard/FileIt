using System;
using System.IO;
using FileIt.Interaces;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.FindReplace
{
    public class FindReplaceInFileName: ISingleFileProcessor
    {
        public void Dispose()
        {
        }

        public void Process(FlexibleStream stream, string[] args)
        {
            var argProvider = new ArgumentProvider(args);
            var fileName = Path.GetFileName(stream.GetFileName());
            var newFileName = fileName.Replace(argProvider.FindWhat, argProvider.ReplaceWith);
            Console.WriteLine($"{fileName} --> {newFileName}");
            var newFilePath = stream.GetFileName().Replace(fileName, newFileName);
            File.Move(stream.GetFileName(), newFilePath);
        }

        public void Init(string path)
        {
        }
    }
}
