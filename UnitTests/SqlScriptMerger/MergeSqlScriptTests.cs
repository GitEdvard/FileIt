using System;
using FileIt.SqlScriptMerger;
using FlexibleStreamHandling;
using NUnit.Framework;

namespace UnitTests.SqlScriptMerger
{
    [TestFixture]
    class MergeSqlScriptTests
    {
        [Test]
        public void MergeScripts_FilesWithUseHeader_AggregatedFileOnlyOneUseStatement()
        {
            //Arrange
            var file1 = "use gtdb2_devel" + Environment.NewLine +
                        "Command 1" + Environment.NewLine +
                        "Command 2";

            var file2 = Environment.NewLine + "use [gtdb2_devel]" + Environment.NewLine +
                        "Command 3";

            var file3 = " use [gtdb2_devel]" + Environment.NewLine +
                        "Command 4";

            //Act
            var outstream = new StringReader();
            var fileMerger = new FileMerger(outstream);
            fileMerger.Append(new StringReader(file1));
            fileMerger.Append(new StringReader(file2));
            fileMerger.Append(new StringReader(file3));

            //Assert
            var expected =
                "use <enter database>" + Environment.NewLine +
                "Command 1" + Environment.NewLine +
                "Command 2" + Environment.NewLine +
                "Command 3" + Environment.NewLine +
                "Command 4" + Environment.NewLine;
            var actual = outstream.GetReader().ReadToEnd();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MergeScripts_SomeFilesLackUseStatement_AggregatedFileOnlyOneUseStatement()
        {
            //Arrange
            var file1 = "use gtdb2_devel" + Environment.NewLine +
                        "Command 1" + Environment.NewLine +
                        "Command 2";

            var file2 = "Command 3";

            var file3 = " use [gtdb2_devel]" + Environment.NewLine +
                        "Command 4";

            //Act
            var outstream = new StringReader();
            var fileMerger = new FileMerger(outstream);
            fileMerger.Append(new StringReader(file1));
            fileMerger.Append(new StringReader(file2));
            fileMerger.Append(new StringReader(file3));

            //Assert
            var expected =
                "use <enter database>" + Environment.NewLine +
                "Command 1" + Environment.NewLine +
                "Command 2" + Environment.NewLine +
                "Command 3" + Environment.NewLine +
                "Command 4" + Environment.NewLine;
            var actual = outstream.GetReader().ReadToEnd();
            Assert.AreEqual(expected, actual);
        }
    }
}
