using System;

namespace FileIt.Interaces
{
    public interface ISingleFileProcessor: IDisposable
    {
        /// <summary>
        /// This is called within a loop, iterating over all files.
        /// </summary>
        /// <param name="file"></param>
        void Process(string file, string[] args);

        void Init(string path);
    }
}