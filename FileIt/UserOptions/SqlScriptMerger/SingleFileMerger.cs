using System;
using System.IO;
using FileIt.Interaces;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.SqlScriptMerger
{
    public class SingleFileMerger: ISingleFileProcessor, IDisposable
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

        public void Process(string file)
        {
            var fileName = Path.GetFileName(file);
            Console.WriteLine(fileName);
            using (var stream = new FileIOStream(file))
            {
                _fileMerger.Append(stream);
            }
        }

        public void Dispose()
        {
            _outputStream?.Dispose();
        }
    }
}
