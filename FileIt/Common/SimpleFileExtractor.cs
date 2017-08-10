using System.IO;

namespace FileIt.Common
{
    public class SimpleFileExtractor : FileExtractor
    {
        public SimpleFileExtractor(string defaultPattern) : base(defaultPattern)
        {
        }
        
        public override string[] ExtractFiles(string path)
        {
            var files = Directory.GetFiles(path, DefaultPattern, SearchOption.AllDirectories);
            return files;
        }
    }
}
