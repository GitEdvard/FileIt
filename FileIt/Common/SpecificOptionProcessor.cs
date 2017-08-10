using FileIt.Interaces;

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
        protected abstract IArgumentChecker ArgumentChecker { get; }
        protected abstract ISingleFileProcessor SingleFileProcessor { get; }

        protected abstract FileExtractor FileExtractor { get; }

        public void Process(string[] args)
        {
            using (var singleFileProcessor = SingleFileProcessor)
            {
                var multiFileProcessor = new MultipleFileProcessor(ArgumentChecker,
                    singleFileProcessor, FileExtractor);
                multiFileProcessor.Process(args);
            }
        }
    }
}