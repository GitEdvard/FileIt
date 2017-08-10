using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileIt.Interaces;

namespace FileIt.ChangeCodePage
{
    class SingleFileConverter : ISingleFileProcessor
    {
        public void Process(string file)
        {
            Console.WriteLine("Input file: {0}", file);
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    lines.Add(line);
                }
            }
            using (var sw = new StreamWriter(file, false, Encoding.GetEncoding(1252)))
            {
                foreach (var line in lines)
                {
                    sw.WriteLine(line);
                }
            }
            Console.WriteLine("...Converted");

        }

        public void Init(string path)
        {
        }

        public void Dispose()
        {
        }
    }
}