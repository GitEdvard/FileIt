using FileIt.Common;
using FileIt.Interaces;
using FileIt.Interfaces;

namespace FileIt.UserOptions.ChangeCodePage
{
    public class CodePageProcessor : SpecificOptionProcessor
    {
        public CodePageProcessor(string[] args, IOsService osService) : base(args, osService)
        {
        }

        protected override IArgumentChecker ArgumentChecker => new SingleArgumentPathChecker();
        protected override ISingleFileProcessor SingleFileProcessor => new SingleFileConverter(OsService);
        protected override FileExtractor FileExtractor => new SimpleFileExtractor("*.sql");
    }
}