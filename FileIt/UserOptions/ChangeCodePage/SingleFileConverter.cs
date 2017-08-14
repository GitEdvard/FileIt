using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileIt.Interaces;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.ChangeCodePage
{
    class SingleFileConverter : ISingleFileProcessor
    {
        public void Process(FlexibleStream stream, string[] args)
        {
            Console.WriteLine("Input file: {0}", stream.GetFileName());
            List<string> lines = new List<string>();
            var sr = stream.GetReader();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                lines.Add(line);
            }
            foreach (var line in lines)
            {
                stream.WriteLine(line);
            }
            Console.WriteLine("...Converted");
        }

        public void Init(string path)
        {
        }

        public void Dispose()
        {
        }

        public FlexibleStream CreateStream(string path)
        {
            return new FileIOStream(path);
        }
    }
}