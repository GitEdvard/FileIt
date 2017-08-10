using System;
using System.IO;
using FileIt.Interaces;

namespace FileIt.Common
{
    public class SingleArgumentPathChecker : IArgumentChecker
    {
        /// <summary>
        /// The first argument in args is proper in order to come this far. 
        /// </summary>
        /// <param name="args">program input</param>
        public void CheckArgument(string[] args)
        {
            if (args.Length == 1)
            {
                throw new ArgumentException("Path or filename is not specified");
            }
            string fullPath;
            // will cast argument exception if argument is not a path
            try
            {
                fullPath = Path.GetFullPath(args[1]);
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
    }
}