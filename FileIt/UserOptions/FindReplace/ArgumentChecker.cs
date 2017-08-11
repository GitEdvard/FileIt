using FileIt.Common;
using FileIt.Interaces;

namespace FileIt.UserOptions.FindReplace
{
    public class ArgumentChecker: IArgumentChecker
    {
        public void CheckArgument(string[] args)
        {
            var checker = new ArgumentCheckLibrary();
            var argumentProvider = new ArgumentProvider(args);
            checker.CheckHasAtLeastNumberOfArguments(args, 3);
            checker.CheckIsPath(argumentProvider.Path);
            checker.CheckIsPattern(argumentProvider.Pattern);
        }
    }
}
