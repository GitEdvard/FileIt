using System;
using System.IO;

namespace FileIt.Common
{
    public class ArgumentCheckLibrary
    {
        public void CheckIsPath(string pathArgument)
        {
            string fullPath;
            try
            {
                fullPath = Path.GetFullPath(pathArgument);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("The specified path does not exist!");
            }
            try
            {
                var attr = File.GetAttributes(fullPath);
            }
            catch (Exception)
            {
                throw new ArgumentException("The specified path does not exist!");
            }

        }

        public void CheckIsPattern(string patternArgument)
        {
            if (!patternArgument.Trim().StartsWith("*."))
            {
                throw new ArgumentException($"Argument for extention pattern is not starting with '*.'");
            }
        }

        /// <summary>
        /// Check maximum number of arguments
        /// </summary>
        /// <param name="args">Program parameter</param>
        /// <param name="numberArgs">Number of arguments of the current option, excluding the option itself</param>
        public void CheckHasNotMoreArgumentsThan(string[] args, int numberArgs)
        {
            if (args.Length > numberArgs + 1)
            {
                throw new ArgumentException("Too many arguments");
            }
        }
        /// <summary>
        /// Check minimum number of arguments
        /// </summary>
        /// <param name="args">Program parameter</param>
        /// <param name="numberArgs">Number of arguments of the current option, excluding the option itself</param>
        public void CheckHasAtLeastNumberOfArguments(string[] args, int numberArgs)
        {
            if (args.Length < numberArgs + 1)
            {
                throw new ArgumentException("Too few arguments");
            }
        }
    }
}
