using FileIt.Common;
using FileIt.Interaces;

namespace FileIt.UserOptions.ChangeCodePage
{
    public class CodePageProcessor : SpecificOptionProcessor
    {
        public CodePageProcessor(string[] args) : base(args)
        {
        }

        protected override IArgumentChecker ArgumentChecker => new SingleArgumentPathChecker();
        protected override ISingleFileProcessor SingleFileProcessor => new SingleFileConverter();
        protected override FileExtractor FileExtractor => new SimpleFileExtractor("*.sql");
    }
}