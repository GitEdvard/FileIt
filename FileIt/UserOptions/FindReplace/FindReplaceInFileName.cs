using System;
using System.IO;
using FileIt.Interaces;
using FileIt.Interfaces;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.FindReplace
{
    public class FindReplaceInFileName: ISingleFileProcessor
    {
        private readonly IOsService _osService;

        public FindReplaceInFileName(IOsService osService)
        {
            _osService = osService;
        }

        public void Dispose()
        {
        }

        public void Process(FlexibleStream stream, string[] args)
        {
            var argProvider = new ArgumentProvider(args);
            var fileName = _osService.GetFileName(stream.GetFileName());
            var newFileName = fileName.Replace(argProvider.FindWhat, argProvider.ReplaceWith);
            _osService.WriteLineToConsole($"{fileName} --> {newFileName}");
            var newFilePath = stream.GetFileName().Replace(fileName, newFileName);
            _osService.MoveFile(stream.GetFileName(), newFilePath);
        }

        public void Init(string path)
        {
        }

        public FlexibleStream CreateStream(string path)
        {
            return new FileIOStream(path);
        }
    }
}
