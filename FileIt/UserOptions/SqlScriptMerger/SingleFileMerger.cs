using System;
using System.IO;
using FileIt.Interaces;
using FileIt.Interfaces;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.SqlScriptMerger
{
    public class SingleFileMerger: ISingleFileProcessor
    {
        private FileIOStream _outputStream;
        private FileMerger _fileMerger;
        private readonly IOsService _osService;

        public SingleFileMerger(IOsService osService)
        {
            _osService = osService;
        }

        public void Init(string path)
        {
            var outputPath = Path.Combine(path, Constants.OutputFilename);
            _osService.WriteLineToConsole($"Writing aggregated sql script to \n{outputPath}");
            _outputStream = new FileIOStream(outputPath, FileMode.Create, FileAccess.Write);
            _fileMerger = new FileMerger(_outputStream);
        }

        public void Process(FlexibleStream stream, string[] args)
        {
            var fileName = _osService.GetFileName(stream.GetFileName());
            _osService.WriteLineToConsole(fileName);
            _fileMerger.Append(stream);
        }

        public void Dispose()
        {
            _outputStream?.Dispose();
        }

        public FlexibleStream CreateStream(string path)
        {
            return new FileIOStream(path);
        }
    }
}
