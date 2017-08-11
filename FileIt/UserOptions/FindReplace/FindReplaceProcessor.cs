using FileIt.Common;
using FileIt.Interaces;

namespace FileIt.UserOptions.FindReplace
{
    public class FindReplaceProcessor: SpecificOptionProcessor
    {
        public FindReplaceProcessor(string[] args) : base(args)
        {
        }

        protected override IArgumentChecker ArgumentChecker => new ArgumentChecker();
        protected override ISingleFileProcessor SingleFileProcessor => new FindReplaceInFileName();
        protected override FileExtractor FileExtractor => new SimpleFileExtractor(_args[2]);
    }
}
