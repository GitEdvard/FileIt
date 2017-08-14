using FileIt;
using FileIt.Common;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    //[Ignore("Dependent on local file structure")]
    class LoopFilesTests
    {
        [Test]
        public void TestLoopFilesByDir()
        {
            var path = @"C:\Smajobb\Misc\Test code\ReplaceIsNull\ReplaceIsNull";
            var iter = new StandardFileExtractor("*.cs");
            var files = iter.ExtractFiles(path);
            Assert.AreEqual(10, files.Length);
        }

        [Test]
        public void TestIsDirectory()
        {
            var path = @"C:\Smajobb\Misc\Test code\ReplaceIsNull\ReplaceIsNull";
            var iter = new StandardFileExtractor("");
            Assert.IsTrue(iter.IsDirectory(path)); 
        }

        [Test]
        public void TestIsFile()
        {
            var path = @"C:\Smajobb\Misc\Test code\ReplaceIsNull\ReplaceIsNull\ReplaceIsNull.csproj";
            var iter = new StandardFileExtractor("");
            Assert.IsFalse(iter.IsDirectory(path));

        }

    }
}
