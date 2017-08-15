using FileIt.Interaces;
using FileIt.Interfaces;

namespace FileIt.Common
{
    /// <summary>
    /// Each FileIt option is matched with a SpecificOptionProcessor class. Don't use input 
    /// argument to constructor, since input arguments are not checked until Process(args) is called.
    /// This class constitutes from an argument checker, a single file processor and
    /// a file extractor. 
    /// A MultipleFileProcessor is instantiated here. 
    /// </summary>
    public abstract class SpecificOptionProcessor
    {
        protected readonly string[] _args;
        protected readonly IOsService OsService;

        protected SpecificOptionProcessor(string[] args, IOsService osService)
        {
            _args = args;
            OsService = osService;
        }

        protected abstract IArgumentChecker ArgumentChecker { get; }
        protected abstract ISingleFileProcessor SingleFileProcessor { get; }

        protected abstract FileExtractor FileExtractor { get; }

        public void Process()
        {
            using (var singleFileProcessor = SingleFileProcessor)
            {
                var multiFileProcessor = new MultipleFileProcessor(ArgumentChecker,
                    singleFileProcessor, FileExtractor);
                multiFileProcessor.Process(_args);
            }
        }
    }
}