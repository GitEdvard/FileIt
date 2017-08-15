using System;
using System.Collections.Generic;
using System.IO;
using FileIt.Interaces;

namespace FileIt.UserOptions.ReplaceIsNull2
{
    public class SingleFileReplacer: ISingleFileProcessor
    {
        public void Process(string file)
        {
            Console.WriteLine("Input file: {0}", file);
            List<string> lines = new List<string>();
            int replacements = 0;
            var rpl = new Replacer();
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    string replaced;
                    replacements += rpl.Replace(line, out replaced);
                    lines.Add(replaced);
                }
            }
            using (var sw = new StreamWriter(file, false))
            {
                foreach (var line in lines)
                {
                    sw.WriteLine(line);
                }
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
