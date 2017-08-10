﻿using System;
using System.Linq;
using FileIt.Common;
using FlexibleStreamHandling;

namespace FileIt.SqlScriptMerger
{
    public class SqlScriptFileExtractor : FileExtractor, IDisposable
    {
        private FileIOStream _sortFileStream;

        public SqlScriptFileExtractor(string defaultPattern): base(defaultPattern)
        {

        }

        public override string[] ExtractFiles(string path)
        {
            var sortFileFinder = new SimpleFileExtractor(Constants.FileExecuteOrderFileName);
            var sortFilePath = sortFileFinder.ExtractFiles(path).
                ToList().FirstOrDefault();
            Console.WriteLine(sortFilePath != null ? $"Sort file found ({sortFilePath})" : "No sort file found");
            _sortFileStream = sortFilePath != null ? new FileIOStream(sortFilePath) : null;
            var sorter = new FileNameSorter(_sortFileStream, Constants.OutputFilename);
            var extractor = new SimpleFileExtractor(DefaultPattern);
            var files = extractor.ExtractFiles(path);
            return sorter.SortFiles(files);
        }

        public void Dispose()
        {
            _sortFileStream?.Dispose();
        }
    }
}