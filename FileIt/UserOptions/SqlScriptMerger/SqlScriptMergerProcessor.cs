using FileIt.Common;
using FileIt.Interaces;

namespace FileIt.UserOptions.SqlScriptMerger
{
    public class SqlScriptMergerProcessor: SpecificOptionProcessor
    {
        public SqlScriptMergerProcessor(string[] args) : base(args)
        {
        }

        protected override IArgumentChecker ArgumentChecker => new SingleArgumentPathChecker();
        protected override ISingleFileProcessor SingleFileProcessor => new SingleFileMerger();
        protected override FileExtractor FileExtractor => new SqlScriptFileExtractor("*.sql");
    }
}
