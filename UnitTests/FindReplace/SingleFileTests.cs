using System.Text.RegularExpressions;
using FileIt.UserOptions.FindReplace;
using FlexibleStreamHandling;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnitTests.Utility;

namespace UnitTests.FindReplace
{
    [TestFixture]
    class SingleFileTests
    {
        [Test]
        public void FindReplaceInFileNames_FileMatchFindStr_FileNameChanged()
        {
            //Arrange
            var filepath = @"c:\tmp\afilename_mmm.txt";
            var findstr = "mmm";
            string[] args = {"findreplace", ".", "*.txt", findstr};
            var osService = new TestOsService();
            var nameProcessor = new FindReplaceInFileName(osService);

            //Act
            using (var stream = new StringReader("", filepath))
            {
                nameProcessor.Process(stream, args);
            }

            //Assert
            Assert.AreEqual(osService.ChangedFiles.Count, 1);
            Assert.AreEqual(filepath, osService.ChangedFiles[0].Item1);
            Assert.AreEqual(@"c:\tmp\afilename_.txt", osService.ChangedFiles[0].Item2);
        }
        [Test]
        public void FindReplaceInFileNames_CaseMismatch_FilenameChanged()
        {
            //Arrange
            var filepath = @"c:\tmp\afilename_mmm.txt";
            var findstr = "mMm";
            string[] args = { "findreplace", ".", "*.txt", findstr };
            var osService = new TestOsService();
            var nameProcessor = new FindReplaceInFileName(osService);

            //Act
            using (var stream = new StringReader("", filepath))
            {
                nameProcessor.Process(stream, args);
            }

            //Assert
            Assert.AreEqual(osService.ChangedFiles.Count, 1);
            Assert.AreEqual(filepath, osService.ChangedFiles[0].Item1);
            Assert.AreEqual(@"c:\tmp\afilename_.txt", osService.ChangedFiles[0].Item2);

        }

        [Test]
        public void FindReplaceInFileNames_ReplacementTextNotNull_FilenameChanged()
        {
            //Arrange
            var filepath = @"c:\tmp\afilename_mmm.txt";
            var findstr = "mMm";
            var replacestr = "X";
            string[] args = { "findreplace", ".", "*.txt", findstr, replacestr };
            var osService = new TestOsService();
            var nameProcessor = new FindReplaceInFileName(osService);

            //Act
            using (var stream = new StringReader("", filepath))
            {
                nameProcessor.Process(stream, args);
            }

            //Assert
            Assert.AreEqual(osService.ChangedFiles.Count, 1);
            Assert.AreEqual(filepath, osService.ChangedFiles[0].Item1);
            Assert.AreEqual(@"c:\tmp\afilename_X.txt", osService.ChangedFiles[0].Item2);

        }

        [Test]
        public void FindReplaceInFileNames_FileDoNotMatch_FileNotChanged()
        {
            //Arrange
            var filepath = @"c:\tmp\anotherfile.txt";
            var findstr = "mMm";
            string[] args = { "findreplace", ".", "*.txt", findstr };
            var osService = new TestOsService();
            var nameProcessor = new FindReplaceInFileName(osService);

            //Act
            using (var stream = new StringReader("", filepath))
            {
                nameProcessor.Process(stream, args);
            }

            //Assert
            Assert.AreEqual(0, osService.ChangedFiles.Count);
        }
        [Test]
        public void FindReplaceFileName_MatchStringHasDot_DotIsWildcard()
        {
            //Arrange
            var filepath = @"filename_sometext.SomeText.txt";
            var findstr = ".SomeText";
            string[] args = { "findreplace", ".", "*.txt", findstr };
            var osService = new TestOsService();
            var nameProcessor = new FindReplaceInFileName(osService);

            //Act
            using (var stream = new StringReader("", filepath))
            {
                nameProcessor.Process(stream, args);
            }

            //Assert
            Assert.AreEqual(1, osService.ChangedFiles.Count);
            Assert.AreEqual(@"c:\filename.txt", osService.ChangedFiles[0].Item2);
        }

    }
}
