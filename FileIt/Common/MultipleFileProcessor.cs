using System;
using FileIt.Interaces;
using FlexibleStreamHandling;

namespace FileIt.Common
{
    /// <summary>
    /// Here is where the work is done. Iterating through files and processing each file.
    /// This class is instantiated within the SpecificOptionProcessor, which is a factory class. 
    /// </summary>
    public class MultipleFileProcessor
    {
        private readonly IArgumentChecker _argumentChecker;
        private readonly ISingleFileProcessor _singleFileProcessor;
        private readonly FileExtractor _fileExtractor;

        public MultipleFileProcessor(IArgumentChecker argumentChecker, ISingleFileProcessor singleFileProcessor, FileExtractor fileExtractor)
        {
            _argumentChecker = argumentChecker;
            _singleFileProcessor = singleFileProcessor;
            _fileExtractor = fileExtractor;
        }

        public void Process(string[] args)
        {
            try
            {
                _argumentChecker.CheckArgument(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            var pathProvidor = new PathArgumentProvider(args);
            var path = pathProvidor.Path;
            var files = _fileExtractor.IsDirectory(path)
                ? _fileExtractor.ExtractFiles(path)
                : new[] {path};
            Console.WriteLine($"Input path: {path}");
            Console.WriteLine($"Number of files found: {files.Length}");
            var osService = new ProductionOsService();
            _singleFileProcessor.Init(path);
            foreach (var file in files)
            {
                using (var stream = _singleFileProcessor.CreateStream(file))
                {
                    _singleFileProcessor.Process(stream, args);
                }
            }
        }
    }
}