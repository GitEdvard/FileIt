using System;
using System.IO;
using FileIt.Interaces;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.SqlScriptMerger
{
    public class SingleFileMerger: ISingleFileProcessor
    {
        private FileIOStream _outputStream;
        private FileMerger _fileMerger;

        public void Init(string path)
        {
            var outputPath = Path.Combine(path, Constants.OutputFilename);
            Console.WriteLine($"Writing aggregated sql script to \n{outputPath}");
            _outputStream = new FileIOStream(outputPath, FileMode.Create, FileAccess.Write);
            _fileMerger = new FileMerger(_outputStream);
        }

        public void Process(FlexibleStream stream, string[] args)
        {
            var fileName = Path.GetFileName(stream.GetFileName());
            Console.WriteLine(fileName);
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
