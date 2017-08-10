namespace FileIt.Interaces
{
    public interface IArgumentChecker
    {
        /// <summary>
        /// The first argument in args is proper in order to come this far. 
        /// </summary>
        /// <param name="args">program input</param>
        void CheckArgument(string[] args);
    }
}