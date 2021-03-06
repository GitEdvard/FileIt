﻿using System.IO;

namespace FileIt.Common
{
    /// <summary>
    /// List all files given a path and a extension pattern
    /// </summary>
    public abstract class FileExtractor
    {
        public string Pattern;

        protected FileExtractor(string defaultPattern)
        {
            Pattern = defaultPattern;
        }

        public abstract string[] ExtractFiles(string path);

        public bool IsDirectory(string path)
        {
            // Decide if path or file
            var attr = File.GetAttributes(path);
            return (attr & FileAttributes.Directory) == FileAttributes.Directory;
        }
    }
}