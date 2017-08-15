using FileIt.Common;
using FileIt.Interaces;
using FileIt.Interfaces;

namespace FileIt.UserOptions.FindReplace
{
    public class FindReplaceProcessor : SpecificOptionProcessor
    {
        private readonly ArgumentProvider _argumentProvider;

        public FindReplaceProcessor(string[] args, IOsService osService) : base(args, osService)
        {
            _argumentProvider = new ArgumentProvider(args);
        }

        protected override IArgumentChecker ArgumentChecker => new ArgumentChecker();
        protected override ISingleFileProcessor SingleFileProcessor => new FindReplaceInFileName(OsService);
        protected override FileExtractor FileExtractor => new StandardFileExtractor(_argumentProvider.Pattern);
    }
}