namespace FileIt.Interfaces
{
    /// <summary>
    /// To be able to replace operating system commands in test environment.
    /// </summary>
    public interface IOsService
    {
        string GetFileName(string path);
        void WriteLineToConsole(string str);
        void MoveFile(string sourceFileName, string destFileName);
    }
}
