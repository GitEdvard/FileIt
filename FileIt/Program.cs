using System;
using FileIt.Common;
using FileIt.UserOptions.ChangeCodePage;
using FileIt.UserOptions.ReplaceIsNull2;
using FileIt.UserOptions.SqlScriptMerger;

namespace FileIt
{
    class Program
    {
        static void Main(string[] args)
        {
            var fncCall = args[0];
            SpecificOptionProcessor specificOptionProcessor = null;
            switch (fncCall.ToLower())
            {
                case "help":
                case "-h":
                    if (args.Length > 1)
                    {
                        WriteSpecificHelp(args[1]);
                    }
                    else
                    {
                        WriteHelpList();
                    }
                    break;
                case "changecodepage":
                    specificOptionProcessor = new CodePageProcessor();
                    break;
                case "replaceisnull":
                    specificOptionProcessor = new ReplaceIsNullProcessor();
                    break;
                case "sqlscriptmerger":
                    specificOptionProcessor = new SqlScriptMergerProcessor();
                    break;
                default:
                    Console.WriteLine("Unknown option");
                    return;
            }
            specificOptionProcessor?.Process(args);
        }

        private static void WriteHelpList()
        {
            var str = @"Options:
    ChangeCodePage <path>
    FindReplace <path> <pattern>
    ReplaceIsNull <path>
    SqlScriptMerger <path>
    help, -h <option>: shows details about option";
            Console.WriteLine(str);
        }

        private static void WriteSpecificHelp(string command)
        {
            string str;
            switch (command.ToLower())
            {
                case "changecodepage":
                    str = @"ChangeCodePage <path>

Recursively changes code page for all .sql files under
the specified path.
Use '.' for current path. ";
                    break;
                case "replaceisnull":
                    str = @"ReplaceIsNull <path>

Recursively replaces all IsNull() and IsNotNull() function
calls in all .cs files under the specified path.
Use '.' for current path. ";
                    break;
                case "sqlscriptmerger":
                    str = @"SqlScriptMerger <path>

This script merge together all sql script in a given folder

Input: path for a folder in which the sql scripts are contained
Input (optional): a file named {FileExecuteOrderFileName} that is placed in 
the given folder. If this file exists, the files are merged in the given 
order in file. Files omitted in the sortfile will be placed after the 
given files.

Output: A new file {OutputFilename} with all the scripts
The 'use <database>' statements are removed from individual scripts, and
replaced with one single 'use <database>' statement in the aggregated file";
                    str = str.Replace("{FileExecuteOrderFileName}", Constants.FileExecuteOrderFileName);
                    str = str.Replace("{OutputFilename}", Constants.OutputFilename);
                    break;
                case "findreplace":
                    str = @"FindReplace <path> <pattern> <find what> [<replace with>]

Recursively changes file names with the <pattern> extension,
starting at the <path> directory. Replaces the <find what> string 
found in file names with the <replace with> string. Omit 
<replace with> to replace with nothing.

Example:
FindReplace . *.txt something somethingelse";
                    break;
                default:
                    str = $"No help text found for option {command}";
                    break;
            }
            Console.WriteLine(str);
        }
    }
}
