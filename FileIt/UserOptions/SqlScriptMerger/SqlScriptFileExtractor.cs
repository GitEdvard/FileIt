using System;
using System.Linq;
using FileIt.Common;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.SqlScriptMerger
{
    public class SqlScriptFileExtractor : FileExtractor, IDisposable
    {
        private FileIOStream _sortFileStream;

        public SqlScriptFileExtractor(string defaultPattern): base(defaultPattern)
        {

        }

        public override string[] ExtractFiles(string path)
        {
            var sortFileFinder = new StandardFileExtractor(Constants.FileExecuteOrderFileName);
            var sortFilePath = sortFileFinder.ExtractFiles(path).
                ToList().FirstOrDefault();
            Console.WriteLine(sortFilePath != null ? $"Sort file found ({sortFilePath})" : "No sort file found");
            _sortFileStream = sortFilePath != null ? new FileIOStream(sortFilePath) : null;
            var sorter = new FileNameSorter(_sortFileStream, Constants.OutputFilename);
            var extractor = new StandardFileExtractor(Pattern);
            var files = extractor.ExtractFiles(path);
            return sorter.SortFiles(files);
        }

        public void Dispose()
        {
            _sortFileStream?.Dispose();
        }
    }
}