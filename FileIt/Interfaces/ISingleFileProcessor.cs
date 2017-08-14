using System;
using FlexibleStreamHandling;

namespace FileIt.Interaces
{
    public interface ISingleFileProcessor: IDisposable
    {
        /// <summary>
        /// This is called within a loop, iterating over all files.
        /// </summary>
        void Process(FlexibleStream stream, string[] args);

        void Init(string path);

        FlexibleStream CreateStream(string path);
    }
}