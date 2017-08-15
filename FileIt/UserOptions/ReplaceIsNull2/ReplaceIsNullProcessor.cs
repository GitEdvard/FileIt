using FileIt.Common;
using FileIt.Interaces;

namespace FileIt.UserOptions.ReplaceIsNull2
{
    public class ReplaceIsNullProcessor: SpecificOptionProcessor
    {
        protected override IArgumentChecker ArgumentChecker => new SingleArgumentPathChecker();
        protected override ISingleFileProcessor SingleFileProcessor => new SingleFileReplacer();
        protected override FileExtractor FileExtractor => new SimpleFileExtractor("*.cs");
    }
}
