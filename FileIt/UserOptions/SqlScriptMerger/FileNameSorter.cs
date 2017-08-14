using System.Collections.Generic;
using System.Linq;
using FlexibleStreamHandling;

namespace FileIt.UserOptions.SqlScriptMerger
{
    public class FileNameSorter
    {
        private readonly FlexibleStream _sortOrder;
        private readonly string _outputFileName;

        public FileNameSorter(FlexibleStream sortOrder, string outputFileName)
        {
            _sortOrder = sortOrder;
            _outputFileName = outputFileName;
        }

        public string[] SortFiles(string[] files)
        {
            var filteredFiles = SortOutOutputFile(files);
            if (_sortOrder == null) return filteredFiles;
            var sortOrder = new List<string>();
            var reader = _sortOrder.GetReader();
            while (!reader.EndOfStream)
            {
                sortOrder.Add(reader.ReadLine());
            }
            var sortedList = filteredFiles.ToList();
            sortedList.Sort(new FileComparer(sortOrder));

            return sortedList.ToArray();
        }

        private string[] SortOutOutputFile(string[] files)
        {
            return files.ToList().Where(f => !f.Contains(_outputFileName)).ToArray();
        }

        private class FileComparer : IComparer<string>
        {
            private readonly List<string> _givenSortOrder;

            public FileComparer(List<string> givenSortOrder)
            {
                _givenSortOrder = givenSortOrder;
            }

            public int Compare(string x, string y)
            {
                var indX = _givenSortOrder.FindIndex(s => x.ToLower().Contains(s.ToLower()));
                var indY = _givenSortOrder.FindIndex(s => y.ToLower().Contains(s.ToLower()));
                indX = indX == -1 ? int.MaxValue : indX;
                indY = indY == -1 ? int.MaxValue : indY;
                if (indX < indY)
                {
                    return -1;
                }
                return indX > indY ? 1 : 0;
            }
        }
    }
}
