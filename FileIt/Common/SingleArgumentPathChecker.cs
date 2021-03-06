﻿using System;
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
            var checker = new ArgumentCheckLibrary();
            var pathProvider = new PathArgumentProvider(args);

            try
            {
                checker.CheckHasAtLeastNumberOfArguments(args, 1);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Path or filename is not specified");
            }

            checker.CheckIsPath(pathProvider.Path);
        }
    }
}