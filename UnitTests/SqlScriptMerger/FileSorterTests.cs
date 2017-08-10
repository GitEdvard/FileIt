using System;
using FileIt.SqlScriptMerger;
using FlexibleStreamHandling;
using NUnit.Framework;

namespace UnitTests.SqlScriptMerger
{
    [TestFixture]
    class FileSorterTests
    {
        [Test]
        public void SortFiles_SomeFilesInSortFile_FilesInSortFileFirst()
        {
            //Arrange
            var files = new string[]
            {
                "P:/<path>/file1",
                "P:/<path>/file2",
                "P:/<path>/aggregated_file",
                "P:/<path>/file3",
                "P:/<path>/file4",
                "P:/<path>/file5"
            };
            var sortOrderContents =
                "file4" + Environment.NewLine +
                "file2";
            var sortOrderStream = new StringReader(sortOrderContents);

            //Act
            var fileSorter = new FileNameSorter(sortOrderStream, "aggregated_file");
            var sortedFiles = fileSorter.SortFiles(files);

            //Assert
            var expectedArray = new string[]
            {
                "P:/<path>/file4",
                "P:/<path>/file2",
                "P:/<path>/file1",
                "P:/<path>/file3",
                "P:/<path>/file5"
            };
            var expected = string.Join(", ", expectedArray);
            var actual = string.Join(", ", sortedFiles);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortFiles_FlexibleStreamIsNull_FileSortOrderUnchanged()
        {
            //Arrange
            var files = new string[]
            {
                "file1",
                "file2",
                "file3",
                "file4",
                "file5"
            };

            //Act
            var fileSorter = new FileNameSorter(null, "the_output_file_name");
            var sortedFiles = fileSorter.SortFiles(files);

            //Assert
            var expectedArray = new string[]
            {
                "file1",
                "file2",
                "file3",
                "file4",
                "file5"
            };
            var expected = string.Join(", ", expectedArray);
            var actual = string.Join(", ", sortedFiles);
            Assert.AreEqual(expected, actual);
        }

    }
}
