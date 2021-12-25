using System;
using System.Text.RegularExpressions;

namespace Task5_2
{
    public class Isbn
    {
        private const string IsbnRegexString = @"\d{3}-\d{1}-\d{2}-\d{6}-\d{1}$|\d{13}$";
        private readonly Regex _isbnRegex = new(IsbnRegexString);
        private readonly string _isbn;

        public Isbn(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
            {
                throw new ArgumentException("Must be not null", nameof(isbn));
            }

            if (_isbnRegex.IsMatch(isbn))
            {
                _isbn = isbn.Replace("-", "");
            }
            else
            {
                throw new ArgumentException("invalid isbn format", nameof(isbn));
            }
        }

        public override string ToString() => _isbn;

        public override bool Equals(object obj) => obj is Isbn isbn && isbn._isbn == _isbn;

        public override int GetHashCode() => _isbn.GetHashCode();
    }
}