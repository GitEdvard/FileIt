using System;
using System.Collections.Generic;
using System.IO;
using FileIt.Interaces;
using FileIt.Interfaces;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.ReplaceIsNull2
{
    public class SingleFileReplacer: ISingleFileProcessor
    {
        private readonly IOsService _osService;

        public SingleFileReplacer(IOsService osService)
        {
            _osService = osService;
        }

        public void Process(FlexibleStream stream, string[] args)
        {
            _osService.WriteLineToConsole($"Input file: {stream.GetFileName()}");
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
            var underlying_stream = stream.Stream;
            underlying_stream.Position = 0;
            foreach (var line in lines)
            {
                stream.WriteLine(line);
            }
            _osService.WriteLineToConsole("Replaced IsNull and IsNotNull {replacements} occurences");
        }

        public void Init(string path)
        {
        }

        public void Dispose()
        {
        }

        public FlexibleStream CreateStream(string path)
        {
            return new FileIOStream(path, FileMode.Open, FileAccess.ReadWrite);
        }
    }
}
