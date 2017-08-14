using FileIt.Common;
using FileIt.Interaces;
using FileIt.Interfaces;

namespace FileIt.UserOptions.ReplaceIsNull2
{
    public class ReplaceIsNullProcessor: SpecificOptionProcessor
    {
        public ReplaceIsNullProcessor(string[] args, IOsService osService) : base(args, osService)
        {
        }

        protected override IArgumentChecker ArgumentChecker => new SingleArgumentPathChecker();
        protected override ISingleFileProcessor SingleFileProcessor => new SingleFileReplacer(OsService);
        protected override FileExtractor FileExtractor => new SimpleFileExtractor("*.cs");
    }
}
