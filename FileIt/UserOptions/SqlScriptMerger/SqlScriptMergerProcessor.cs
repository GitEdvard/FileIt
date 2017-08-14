using FileIt.Common;
using FileIt.Interaces;
using FileIt.Interfaces;

namespace FileIt.UserOptions.SqlScriptMerger
{
    public class SqlScriptMergerProcessor: SpecificOptionProcessor
    {
        public SqlScriptMergerProcessor(string[] args, IOsService osService) : base(args, osService)
        {
        }

        protected override IArgumentChecker ArgumentChecker => new SingleArgumentPathChecker();
        protected override ISingleFileProcessor SingleFileProcessor => new SingleFileMerger(OsService);
        protected override FileExtractor FileExtractor => new SqlScriptFileExtractor("*.sql");
    }
}
