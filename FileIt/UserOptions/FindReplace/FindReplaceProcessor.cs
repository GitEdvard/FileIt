using FileIt.Common;
using FileIt.Interaces;

namespace FileIt.UserOptions.FindReplace
{
    public class FindReplaceProcessor : SpecificOptionProcessor
    {
        private readonly ArgumentProvider _argumentProvider;

        public FindReplaceProcessor(string[] args) : base(args)
        {
            _argumentProvider = new ArgumentProvider(args);
        }

        protected override IArgumentChecker ArgumentChecker => new ArgumentChecker();
        protected override ISingleFileProcessor SingleFileProcessor => new FindReplaceInFileName();
        protected override FileExtractor FileExtractor => new SimpleFileExtractor(_argumentProvider.Pattern);
    }
}