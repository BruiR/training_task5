using System.Collections.Generic;
using System.Linq;

namespace Task5_2
{
    public class Catalog : Dictionary<Isbn, Book>
    {
        public IEnumerable<string> GetSortedBooksNames()
        {
            return this.Select(x => (x.Value.Name))
                .OrderBy(x => x);
        }

        public IEnumerable<Book> GetSortedBooksByAuthors(string author)
        {
            return this.Select(x => x.Value)
                .Where(x => x.GetAuthors().Contains(author))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<(string, int)> GetAuthorsInfo()
        {
            return this.Select(x => x.Value.GetAuthors())
                .SelectMany(x => x)
                .GroupBy(x => x)
                .Select(x => (x.Key, x.Count()));
        }
    }
}