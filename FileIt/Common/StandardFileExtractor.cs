using System.IO;

namespace FileIt.Common
{
    /// <summary>
    /// Recursively extracts all file names (full path), given a directory.
    /// </summary>
    public class StandardFileExtractor : FileExtractor
    {
        public StandardFileExtractor(string defaultPattern) : base(defaultPattern)
        {
        }
        
        public override string[] ExtractFiles(string path)
        {
            var files = Directory.GetFiles(path, Pattern, SearchOption.AllDirectories);
            return files;
        }
    }
}
