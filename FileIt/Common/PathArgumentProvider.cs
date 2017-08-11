namespace FileIt.Common
{
    public class PathArgumentProvider
    {
        private readonly string[] _args;

        public PathArgumentProvider(string[] args)
        {
            _args = args;
        }

        public string Path => _args.Length > 1 ? _args[1] : null;
    }
}
