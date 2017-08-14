using System;
using System.Collections.Generic;
using System.IO;
using FileIt.Interaces;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.ReplaceIsNull2
{
    public class SingleFileReplacer: ISingleFileProcessor
    {
        public void Process(FlexibleStream stream, string[] args)
        {
            Console.WriteLine("Input file: {0}", stream.GetFileName());
            List<string> lines = new List<string>();
            int replacements = 0;
            var rpl = new Replacer();
            var sr = stream.GetReader();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                string replaced;
                replacements += rpl.Replace(line, out replaced);
                lines.Add(replaced);
            }
            foreach (var line in lines)
            {
                stream.WriteLine(line);
            }
            Console.WriteLine("Replaced IsNull and IsNotNull {0} occurences", replacements);
        }

        public void Init(string path)
        {
        }

        public void Dispose()
        {
        }
    }
}
