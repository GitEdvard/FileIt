using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileIt.Interaces;
using FileIt.Interfaces;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.ChangeCodePage
{
    class SingleFileConverter : ISingleFileProcessor
    {
        private readonly IOsService _osService;

        public SingleFileConverter(IOsService osService)
        {
            _osService = osService;
        }

        public void Process(FlexibleStream stream, string[] args)
        {
            _osService.WriteLineToConsole($"Input file: {stream.GetFileName()}");
            List<string> lines = new List<string>();
            var sr = stream.GetReader();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                lines.Add(line);
            }

            stream.ReOpenAs(FileMode.Create, FileAccess.Write);
            foreach (var line in lines)
            {
                stream.WriteLine(line);
            }
            _osService.WriteLineToConsole("...Converted");
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