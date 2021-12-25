using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5_1
{
    public class SparseMatrix : IEnumerable<long>
    {
        private readonly Dictionary<(int, int), long> _elements = new();
        public int Columns { get; }
        public int Rows { get; }

        public SparseMatrix(int rows, int columns)
        {
            Rows = (rows > 0) ? rows : throw new ArgumentException("Must be > 0", nameof(rows));
            Columns = (columns > 0) ? columns : throw new ArgumentException("Must be > 0", nameof(columns));
        }

        public long this[int i, int j]
        {
            get
            {
                CheckSizeOfIndexes(i, j);
                return _elements.TryGetValue((i, j), out var value) ? value : default;
            }
            set
            {
                CheckSizeOfIndexes(i, j);
                if (value == 0)
                {
                    _elements.Remove((i, j));
                }
                else
                {
                    _elements[(i, j)] = value;
                }
            }
        }

        public override string ToString()
        {
            var outputString = new StringBuilder();
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    outputString.AppendFormat("{0,12}", this[i, j]);
                }

                outputString.AppendLine();
            }

            return outputString.ToString();
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<(int, int, long)> GetNonzeroElements()
        {
            return _elements.Select(x => (x.Key.Item1, x.Key.Item2, x.Value))
                .OrderBy(x => x.Item2)
                .ThenBy(x => x.Item1);
        }

        public int GetCount(long number)
        {
            if (number == 0)
            {
                return Columns * Rows - _elements.Count;
            }

            return _elements.Count(x => x.Value == number);
        }

        private void CheckSizeOfIndexes(int i, int j)
        {
            if (i < 0 || i >= Rows)
            {
                throw new IndexOutOfRangeException("Rows index");
            }

            if (j < 0 || j >= Columns)
            {
                throw new IndexOutOfRangeException("Columns index");
            }
        }
    }
}