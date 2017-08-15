using FileIt.Common;

namespace FileIt.UserOptions.FindReplace
{
    public class ArgumentProvider
    {
        private readonly string[] _args;
        private readonly PathArgumentProvider _pathProvider;

        public ArgumentProvider(string[] args)
        {
            _args = args;
            _pathProvider = new PathArgumentProvider(args);
        }

        public string Pattern => _args.Length >= 3 ? _args[2] : null;

        public string Path => _pathProvider.Path;

        public string FindWhat => _args.Length >= 4 ? _args[3] : null;

        public string ReplaceWith => _args.Length >= 5 ? _args[4] : "";
    }
}