using FileIt.Common;
using FileIt.Interaces;

namespace FileIt.UserOptions.FindReplace
{
    public class ArgumentChecker: IArgumentChecker
    {
        public void CheckArgument(string[] args)
        {
            var checker = new ArgumentCheckLibrary();
            checker.CheckHasAtLeastNumberOfArguments(args, 3);
            checker.CheckIsPath(args, 1);
            checker.CheckIsPattern(args, 2);
        }
    }
}
