using System;
using System.Collections.Generic;

namespace Task5_2
{
    public class Book
    {
        public string Name { get; }
        public DateTime? Date { get; }
        private readonly HashSet<string> _authors;

        public Book(string name, DateTime? date, HashSet<string> authors)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Must be not null", nameof(name));
            }

            Name = name;
            Date = date;
            _authors = authors;
        }

        public IEnumerable<string> GetAuthors() => _authors;
    }
}