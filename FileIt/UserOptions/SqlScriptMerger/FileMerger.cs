using System.IO;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.SqlScriptMerger
{
    public class FileMerger
    {
        private readonly FlexibleStream _outStream;

        public FileMerger(FlexibleStream outStream)
        {
            _outStream = outStream;
            outStream.WriteLine("use <enter database>");
        }

        public void Append(FlexibleStream file)
        {
            using (var r = file.GetReader())
            {
                ConsumeUseStatement(r);
                while (!r.EndOfStream)
                {
                    var line =  r.ReadLine();
                    _outStream.WriteLine(line);
                }
            }
        }

        private void ConsumeUseStatement(StreamReader reader)
        {
            while (!reader.EndOfStream && !reader.ReadLine().ToLower().TrimStart().Contains("use "))
            {
                // do nothing
            }
            if (reader.EndOfStream)
            {
                // Reset stream reader if no use statement was found
                reader.BaseStream.Position = 0;
            }

        }
    }
}
