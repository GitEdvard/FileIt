using FileIt.Common;
using FileIt.Interaces;

namespace FileIt.ChangeCodePage
{
    public class CodePageProcessor : SpecificOptionProcessor
    {
        protected override IArgumentChecker ArgumentChecker => new SingleArgumentPathChecker();
        protected override ISingleFileProcessor SingleFileProcessor => new SingleFileConverter();
        protected override FileExtractor FileExtractor => new SimpleFileExtractor("*.sql");
    }
}